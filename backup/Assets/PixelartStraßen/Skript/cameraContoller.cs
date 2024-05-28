using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Assertions;

[RequireComponent(typeof(Camera))]
public class cameraContoller : MonoBehaviour
{   
    private float horizontalInput ;
    private float verticalInput ;
    private float mouseX ;
    private float mouseY ;
    private float mouseMiddle ;
    public float speed = 10;
    public float scrollSpeed = 75 ;
    [SerializeField]
    private Camera cameraFreeWalk;
    [SerializeField]
    private float zoomSpeed = 1;
    [SerializeField]
    private float minZoomFOV = 5;
    [SerializeField]
    private float maxZoomFOV = 10;

    private void Awake()
    {
        cameraFreeWalk = GetComponent<Camera>();
        Assert.IsNotNull(cameraFreeWalk);
    }

    public void ZoomIn()
    {
        cameraFreeWalk.orthographicSize = cameraFreeWalk.orthographicSize - zoomSpeed;
        if (cameraFreeWalk.orthographicSize < minZoomFOV)
        {
            cameraFreeWalk.orthographicSize = minZoomFOV;
        }
    }

    public void ZoomOut()
    {
        cameraFreeWalk.orthographicSize = cameraFreeWalk.orthographicSize + zoomSpeed;
        if (cameraFreeWalk.orthographicSize > maxZoomFOV)
        {
            cameraFreeWalk.orthographicSize = maxZoomFOV;
        }
    }
    void Update()
    {
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");
        mouseMiddle = Input.GetAxis("Fire3");
        transform.Translate(Vector2.right * Time.deltaTime * horizontalInput * speed);
        transform.Translate(Vector2.up * Time.deltaTime * verticalInput * speed);
        transform.Translate(Vector2.right * Time.deltaTime * -mouseX * mouseMiddle * scrollSpeed);
        transform.Translate(Vector2.up * Time.deltaTime * -mouseY * mouseMiddle * scrollSpeed);

        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            ZoomIn();
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            ZoomOut();
        }
    }
}
