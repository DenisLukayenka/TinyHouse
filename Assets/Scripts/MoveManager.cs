using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveManager : MonoBehaviour
{
    private float wallSpeed = 30f;

    public void UpdateForceToList(IEnumerable<GameObject> list, Vector3 vector)
    {
        foreach(var item in list)
        {
            var itemRb = item.GetComponent<Rigidbody>();
            this.UpdateForce(itemRb, vector * wallSpeed);
        }
    }

    private void UpdateForce(Rigidbody objectRb, Vector3 vector)
    {
        this.RemoveForce(objectRb);
        objectRb.AddForce(vector, ForceMode.Impulse);
    }

    private void RemoveForce(Rigidbody objectRb)
    {
        objectRb.velocity = Vector3.zero;
        objectRb.angularVelocity = Vector3.zero;
    }
}
