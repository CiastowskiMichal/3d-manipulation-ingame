using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GizmoMaterialDefinition : MonoBehaviour
{
    [SerializeField]
    GameObject XAxis, YAxis, ZAxis;
    // Start is called before the first frame update
    void Start()
    {
        XAxis.GetComponent<MeshRenderer>().material.SetColor("Axis", new Color(1, 0, 0, 1));
        YAxis.GetComponent<MeshRenderer>().material.SetColor("Axis", new Color(0, 1, 0, 1));
        ZAxis.GetComponent<MeshRenderer>().material.SetColor("Axis", new Color(0, 0, 1, 1));
    }
}
