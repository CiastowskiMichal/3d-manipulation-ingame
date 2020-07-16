using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlVertices : MonoBehaviour
{
    private Vector3 mOffset;
    private float mZCoord;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ControlPosition();
    }
    void ControlPosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit) && Input.GetMouseButton(0))
        {
            if (hit.transform.name.Contains("VertexPoint_"))
            {
                mZCoord = Camera.main.WorldToScreenPoint(hit.transform.position).z;
                hit.transform.position = GetMouseAsWorldPoint();
            }
        }
    }
    private Vector3 GetMouseAsWorldPoint()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = mZCoord;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }
}
