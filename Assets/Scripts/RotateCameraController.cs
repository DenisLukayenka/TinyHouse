using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCameraController : MonoBehaviour
{
    [SerializeField]
    private float rotateSpeed = 10f;

    // Update is called once per frame
    void Update()
    {        
        float horizontalInput = Input.GetAxis("Horizontal");

        this.transform.Rotate(Vector3.down * horizontalInput * this.rotateSpeed * Time.deltaTime);
    }
}
