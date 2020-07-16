using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetMeshInfo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string s = "Vector3[] vertices = new Vector3[] { ";
        string s2 = "int[] triangles = new int[] { ";
        string s3 = "Vector2[] uv = new Vector2[] { ";
        Mesh mesh = this.GetComponent<MeshFilter>().mesh;
        for (int i = 0; i < mesh.vertices.Length; i++)
        {
            s += "new Vector3(" + mesh.vertices[i].x + ", " + mesh.vertices[i].y + ", " + mesh.vertices[i].z + "), ";

        }
        for (int i = 0; i < mesh.triangles.Length; i++)
        {
            s2 += mesh.triangles[i]+", ";
        }
        for (int i = 0; i < mesh.uv.Length; i++)
        {
            s3 += "new Vector2(" + mesh.uv[i].x + ", " + mesh.uv[i].y + "), ";
        }
        s += "}";
        s2 += "}";
        s3 += "}";
        Debug.Log(s);
        Debug.Log(s2);
        Debug.Log(s3);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
