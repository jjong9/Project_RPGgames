using UnityEngine;
using System.Collections;

public class CameraAction : MonoBehaviour
{
    public GameObject player;
    const int orthographicSizeMin = 1;
    const int orthographicSizeMax = 3;
    float MouseScroll;
    Vector3 offset;
    public float RotationSpeed = 0;
    public Transform cameraTransform;
    public Transform pivot;

    // Use this for initialization
    void Start()
    {
        offset = transform.position - player.transform.position;
        pivot.position = player.transform.position;
        cameraTransform.position = pivot.position + offset;
        cameraTransform.parent = pivot.transform;
    }
    void Update()
    {
        
    }
    // Update is called once per frame
    void LateUpdate()
    {
        MouseScroll = Input.GetAxis("Mouse ScrollWheel");
        Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize, orthographicSizeMin, orthographicSizeMax);
        float orthographicSize = Camera.main.orthographicSize;
        if (MouseScroll > 0f)
        {
            if (Camera.main.orthographicSize > orthographicSizeMin)
            {
                Camera.main.orthographicSize -= 0.2f;
            }
        }

        if (MouseScroll < 0f)
        {
            if (Camera.main.orthographicSize < orthographicSizeMax)
            {
                Camera.main.orthographicSize += 0.2f;
            }
        }

        pivot.position = player.transform.position;
        if (Input.GetMouseButton(1))
        {
            transform.RotateAround(pivot.position, Vector3.up, Input.GetAxis("Mouse X") * RotationSpeed);
        }

    }
}
