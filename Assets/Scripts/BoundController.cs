using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundController : MonoBehaviour
{
    void OnTriggerEnter(Collider collider)
    {
        Debug.Log($"collider: {collider.transform.name} is out of bounds");

        var colliderRb = collider.transform.GetComponent<Rigidbody>();
        colliderRb.velocity = Vector3.zero;
        colliderRb.angularVelocity = Vector3.zero;
    }
}
