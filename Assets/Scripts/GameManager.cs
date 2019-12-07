using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private List<GameObject> walls;
    private HashSet<CoroutineObject> inactiveWalls;
    private HashSet<CoroutineObject> activeWalls;
    private RaycastManager raycastManager;

    private float wallRelativeYUp = 4f;
    private float wallSpeed = 8f;
    
    [SerializeField]
    private Camera coreCamera;

    void Start()
    {
        this.walls = GameObject.FindGameObjectsWithTag("Wall").ToList();
        this.raycastManager = GameObject.Find("RaycastManager")?.GetComponent<RaycastManager>();
        var castedWalls = this.raycastManager.CastRayToWalls(this.walls, this.coreCamera.gameObject).Distinct();

        this.inactiveWalls = new HashSet<CoroutineObject>(castedWalls.Select(w => new CoroutineObject(){ GameObject = w }));

        this.activeWalls = new HashSet<CoroutineObject>(this.walls.Where(w => !inactiveWalls.Any(iw => iw.GameObject == w))
                                            .Select(x => new CoroutineObject{GameObject = x }).ToList());

        Debug.Log("Inactive: " + string.Join(", ", inactiveWalls));
        Debug.Log("activeWalls: " + string.Join(", ", activeWalls));

        foreach(var wall in inactiveWalls)
        {
            this.StartCoroutine(this.UpWall(wall, wallRelativeYUp));
        }
    }

    void FixedUpdate()
    {
        this.UpdateWalls();
    }

    private void UpdateWalls()
    {
        var hittedWalls = this.raycastManager.CastRayToWalls(this.walls, this.coreCamera.gameObject).Distinct().ToList();
        var activatedWalls = new List<CoroutineObject>();
        Debug.Log("hittedWalls: " + string.Join(", ", hittedWalls));

        foreach(var inactiveWall in this.inactiveWalls)
        {
            var target = hittedWalls.FirstOrDefault(hitted => hitted == inactiveWall.GameObject);

            if(target is null)
            {
                activatedWalls.Add(inactiveWall);
            }
        }

        activatedWalls.ForEach(wall => 
        {
            if(wall.IsUpdatable)
            {
                this.inactiveWalls.Remove(wall);
                this.StartCoroutine(this.DownWall(wall));
                this.activeWalls.Add(wall);
            }
        });

        for(int i = 0; i < hittedWalls.Count; i++)
        {
            var target = this.activeWalls.FirstOrDefault(a => a.GameObject == hittedWalls[i]);

            if(target != null && target.IsUpdatable)
            {
                this.activeWalls.Remove(target);
                this.StartCoroutine(this.UpWall(target, this.wallRelativeYUp));
                this.inactiveWalls.Add(target);
            }
        }
    }

    IEnumerator UpWall(CoroutineObject coroutineObject, float newY) 
    {   
        var wall = coroutineObject.GameObject.transform.GetChild(0).gameObject;
        coroutineObject.IsUpdatable = false;

        while(wall.transform.localPosition.y <= newY)
        {
            var offSet = Vector3.up * Time.deltaTime * wallSpeed / wall.transform.position.y * 7f;
            if(offSet.y + wall.transform.localPosition.y < newY)
            {
                wall.transform.localPosition += offSet;
                yield return null;
            }
            else
            {
                coroutineObject.IsUpdatable = true;
                wall.transform.localPosition = new Vector3(0, newY, 0);
                yield break;
            }
        }
    }

    IEnumerator DownWall(CoroutineObject coroutineObject) 
    {   
        var wall = coroutineObject.GameObject.transform.GetChild(0).gameObject;
        coroutineObject.IsUpdatable = false;

        while(wall.transform.position.y >= wall.transform.parent.position.y)
        {
            var offSet = (Vector3.up * Time.deltaTime * wallSpeed * Mathf.Abs(wall.transform.localPosition.y));

            if(offSet != Vector3.zero && offSet.y < wall.transform.localPosition.y)
            {
                wall.transform.localPosition -= offSet;
                yield return null;
            }
            else
            {
                coroutineObject.IsUpdatable = true;
                wall.transform.localPosition = Vector3.zero;
                yield break;
            }
        }

        

    }

    private class CoroutineObject
    {
        public GameObject GameObject{ get; set; }
        public bool IsUpdatable { get; set; } = true;
    }
}
