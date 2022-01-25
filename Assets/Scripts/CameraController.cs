using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraController : MonoBehaviour
{
    Camera cam;
    float zoomSpeed = 10;
    float maxSize = 1000;
    float minSize = 100;

    void Start()
    {
        cam = GetComponent<Camera>();
    }

    void Update()
    {
        var zoomAmount = -Input.mouseScrollDelta.y * zoomSpeed;
        if (cam.orthographicSize + zoomAmount > maxSize)
            cam.orthographicSize = maxSize;
        else if (cam.orthographicSize + zoomAmount < minSize)
            cam.orthographicSize = minSize;
        else
            cam.orthographicSize += zoomAmount;
    }
}
