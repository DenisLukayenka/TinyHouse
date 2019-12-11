using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCameraController : MonoBehaviour
{
    [SerializeField]
    private float rotateSpeed = 10f;

    private float cameraZoom = 0.5f;
    private float cameraZoomSpeed = 10f;
    private float maxZoom = 1.5f;
    private float minZoom = 0.3f;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {        
        float horizontalInput = Input.GetAxis("Horizontal");
        this.transform.Rotate(Vector3.down * horizontalInput * this.rotateSpeed * Time.deltaTime);

        var cameraZoomChange = Input.GetAxis("Mouse ScrollWheel") * this.cameraZoomSpeed * Time.deltaTime;

        if((cameraZoomChange > 0 && cameraZoom < maxZoom) || (cameraZoomChange < 0 && cameraZoom > minZoom))
        {
            if(Camera.main.orthographic == false)
            {
                this.ZoomPerspectiveCamera(cameraZoomChange);
            }
            else
            {
                this.ZoomOrthographicCamera(cameraZoomChange);
            }
        }
    }

    private void ZoomPerspectiveCamera(float zoomChange)
    {
        Debug.Log(this.cameraZoom);

        Vector3 direction = this.transform.position - Camera.main.transform.position;
        Debug.DrawRay(Camera.main.transform.position, direction, Color.green);

        Camera.main.transform.Translate(direction * zoomChange, Space.World);

        this.cameraZoom += zoomChange;
    }

    private void ZoomOrthographicCamera(float zoomChange)
    {
        Debug.Log(this.cameraZoom);
        this.cameraZoom += zoomChange;

        Camera.main.orthographicSize -= zoomChange * 7f;
    }
}
