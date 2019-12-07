using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastManager : MonoBehaviour
{
    [SerializeField]
    private Camera mainCamera;
    private float cameraRotation;
    private string maskName = "Walls";

    // Start is called before the first frame update
    void Start()
    {
        /*var oldMask = mainCamera.cullingMask;
        mainCamera.cullingMask = (1 << LayerMask.NameToLayer("Walls"));*/
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetKeyDown("e")){
            StartCoroutine(RotateMe(Vector3.up * 90, 0.8f));
        }
    }

    public IEnumerable<GameObject> CastRayToWalls(List<GameObject> targets, GameObject shooter)
    {
        LayerMask mask = LayerMask.GetMask("Walls");

        foreach(var target in targets)
        {
            Vector3 diraction = target.transform.position - shooter.transform.position;
            Debug.DrawRay(shooter.transform.position, diraction, Color.yellow);
            
            if(Physics.Raycast(shooter.transform.position, diraction, out RaycastHit hit, Mathf.Infinity, mask))
            {
                yield return hit.collider.gameObject;
            }
        }
    }

    void FixedUpdate()
    {
        Transform transform = Camera.main.transform;

        /*if (Input.GetKeyUp("space"))
        {
            // Check for a Wall.
            LayerMask mask = LayerMask.GetMask("Walls");
            // Check if a Wall is hit.
            if (Physics.Raycast(transform.position, transform.forward, 20.0f, mask))
            {
                Debug.Log("Fired and hit a wall");
            }
        }*/
    }

    IEnumerator RotateMe(Vector3 byAngles, float inTime) 
     {   var fromAngle = transform.rotation;
         var toAngle = Quaternion.Euler(transform.eulerAngles + byAngles);
         for(var t = 0f; t < 1; t += Time.deltaTime/inTime) {
             transform.rotation = Quaternion.Slerp(fromAngle, toAngle, t);
             yield return null;
         }
     }
}
