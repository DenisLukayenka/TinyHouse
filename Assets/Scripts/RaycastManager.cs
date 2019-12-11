using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastManager : MonoBehaviour
{
    private float cameraRotation;
    private string maskName = "Walls";

    public IEnumerable<GameObject> CastRayToWalls(List<GameObject> targets, GameObject shooter)
    {
        LayerMask mask = 1 << LayerMask.NameToLayer(maskName);

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

    IEnumerator RotateMe(Vector3 byAngles, float inTime) 
     {   var fromAngle = transform.rotation;
         var toAngle = Quaternion.Euler(transform.eulerAngles + byAngles);
         for(var t = 0f; t < 1; t += Time.deltaTime/inTime) {
             transform.rotation = Quaternion.Slerp(fromAngle, toAngle, t);
             yield return null;
         }
     }
}
