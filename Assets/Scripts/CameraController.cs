using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    Camera Camera1;
    [SerializeField]
    GameObject child;
    private float xMove, yMove;
    private Vector3 translateVector;
    float Zoom = -10;
    float Height;

    private float x, y;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        CameraPan();
        CameraHeightAndZoom();
        CameraPosition();
    }
    void CameraPan()
    {
        if (Input.GetButton("Option") && Input.GetMouseButton(0))
        {
            x = child.transform.localRotation.eulerAngles.x;
            y = this.transform.rotation.eulerAngles.y;
            x -= 3 * Input.GetAxis("Mouse Y");
            y += 3 * Input.GetAxis("Mouse X");
            this.transform.rotation = Quaternion.Euler(this.transform.localRotation.x, y, this.transform.localRotation.z);
            child.transform.localRotation = Quaternion.Euler(x, child.transform.localRotation.y, child.transform.localRotation.z);
        }
    }
    void CameraHeightAndZoom()
    {
        if (Input.mouseScrollDelta.y != 0 && !EventSystem.current.IsPointerOverGameObject())
        {
            if (Input.GetButton("Elevator"))
            {
                Height = this.transform.position.y;
                Height += Input.mouseScrollDelta.y * Time.deltaTime * 10;
                this.transform.position = new Vector3(this.transform.position.x, Height, this.transform.position.z);
            }
            else
            {
                Zoom = Camera1.transform.localPosition.z;
                Zoom += Vector3.forward.z * Input.mouseScrollDelta.y * Time.deltaTime * 10;
                Zoom = Mathf.Clamp(Zoom, -1000, 0);
                Camera1.transform.localPosition = new Vector3(0, 0, Zoom);
            }
        }
    }
    void CameraPosition()
    {
        if (Input.GetButton("Option") && Input.GetMouseButton(2))
        {
            xMove = Input.GetAxis("Mouse X");
            yMove = Input.GetAxis("Mouse Y");
            translateVector = new Vector3(-0.3f * xMove, 0, -0.3f * yMove);
            this.transform.Translate(translateVector);
        }
    }
    public void resetCamera()
    {
        this.transform.position = new Vector3(0, 0, 0);
        child.transform.localRotation = Quaternion.Euler(40, 0, 0);
        this.transform.rotation = Quaternion.Euler(0, 45, 0);
        Zoom = -10;
        Height = this.transform.position.y;
        Camera1.transform.localPosition = new Vector3(0, 0, Zoom);
    }
    public void CenterCameraOnObject(GameObject gameObject)
    {
        this.transform.position = gameObject.transform.position;
        child.transform.localRotation = Quaternion.Euler(40, 0, 0);
        this.transform.rotation = Quaternion.Euler(0, 45, 0);
        Zoom = -10;
        Height = this.transform.position.y;
        Camera1.transform.localPosition = new Vector3(0, 0, Zoom);
    }
}
