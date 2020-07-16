using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PivotController : MonoBehaviour
{
    Vector3 Shift;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SetXShift(InputField inputField)
    {
        float number;
        if (float.TryParse(inputField.text, out number))
        {
            Shift.x = number;
        }
    }
    public void SetYShift(InputField inputField)
    {
        float number;
        if (float.TryParse(inputField.text, out number))
        {
            Shift.y = number;
        }
    }
    public void SetZShift(InputField inputField)
    {
        float number;
        if (float.TryParse(inputField.text, out number))
        {
            Shift.z = number;
        }
    }
    public void ChangePivot()
    {
        if (GameObject.FindGameObjectWithTag("ObjectParams").GetComponent<MeshParams>().ModifyMesh != null)
        {
            GameObject gameObject = GameObject.FindGameObjectWithTag("ObjectParams").GetComponent<MeshParams>().ModifyMesh;
            Vector3[] vectors = gameObject.GetComponent<MeshFilter>().mesh.vertices;
            for (int i = 0; i < gameObject.GetComponent<MeshFilter>().mesh.vertices.Length; i++)
            {
                vectors[i] = new Vector3(vectors[i].x + Shift.x, vectors[i].y + Shift.y, vectors[i].z + Shift.z);
            }
            gameObject.GetComponent<MeshFilter>().mesh.vertices = vectors;
        }
    }
}
