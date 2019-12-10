using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private List<GameObject> walls;
    private HashSet<GameObject> inactiveWalls;
    private HashSet<GameObject> activeWalls;
    private RaycastManager raycastManager;
    private MoveManager moveManager;

    [SerializeField]
    private Inventory Inventory;

    void Start()
    {
        this.walls = GameObject.FindGameObjectsWithTag("Wall").ToList();
        this.raycastManager = GameObject.Find("RaycastManager")?.GetComponent<RaycastManager>();
        this.moveManager = GameObject.Find("MoveManager")?.GetComponent<MoveManager>();

        var castedWalls = this.raycastManager.CastRayToWalls(this.walls, Camera.main.gameObject).Distinct();
        this.inactiveWalls = new HashSet<GameObject>(castedWalls);
        this.activeWalls = new HashSet<GameObject>(this.walls.Where(w => !this.inactiveWalls.Contains(w)));

        this.moveManager.UpdateForceToList(this.ConvertToChildsList(this.inactiveWalls.ToList()), Vector3.up);
    }

    void FixedUpdate()
    {
        this.UpdateWalls();
        if(Input.GetMouseButtonDown(0))
        {
            this.CheckForGameItem();
        }
    }

    private void UpdateWalls()
    {
        var hittedWalls = this.raycastManager.CastRayToWalls(this.walls, Camera.main.gameObject).Distinct().ToList();
        //Debug.Log("hittedWalls: " + string.Join(", ", hittedWalls));

        var newActivatedWalls = this.inactiveWalls.Where(w => !hittedWalls.Contains(w)).ToList();
        newActivatedWalls.ForEach(x => 
        {
            this.inactiveWalls.Remove(x);
            this.activeWalls.Add(x);
        });
        this.moveManager.UpdateForceToList(this.ConvertToChildsList(newActivatedWalls), Vector3.down);


        var newDisabledWalls = hittedWalls.Where(w => this.activeWalls.Contains(w)).ToList();
        newDisabledWalls.ForEach(x => 
        {
            this.activeWalls.Remove(x);
            this.inactiveWalls.Add(x);
        });
        this.moveManager.UpdateForceToList(this.ConvertToChildsList(newDisabledWalls), Vector3.up);
        
    }

    private void CheckForGameItem()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        LayerMask mask = 1 << LayerMask.NameToLayer("GameItems");

        if(Physics.Raycast(ray, out hit, Mathf.Infinity, mask, QueryTriggerInteraction.Collide))
        {
            Debug.Log(hit.collider.transform.name);
            
            IInventoryItem item = hit.collider.GetComponent<IInventoryItem>();
            if(item != null)
            {
                Inventory.AddItem(item);
            }
        }
    }

    private IEnumerable<GameObject> ConvertToChildsList(IEnumerable<GameObject> list)
    {
        return list.Select(e => e.transform.GetChild(0).transform.gameObject);
    }
}
