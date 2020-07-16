using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VertexUpdate : MonoBehaviour
{
    [SerializeField]
    GameObject Parent;
    Corner corner;
    int Id;
    int Vector3;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        if (Parent != null && corner != null)
        {
            //Debug.Log(corner.GetPosition());
            PullSimilarVertices(corner.GetId(), transform.localPosition, Parent.GetComponent<MeshFilter>().mesh.triangles, Parent.GetComponent<MeshFilter>().mesh.vertices, ref Parent);
        }
    }
    
    public void SetParent(GameObject parent)
    {
        this.Parent = parent;
    }
    public void SetCorner(Corner c)
    {
        this.corner = c;
    }
    private List<int> FindRelatedVertices(Vector3 targetPt, bool findConnected, int[] triangles, Vector3[] vertices)
    {
        // list of int
        List<int> relatedVertices = new List<int>();

        int idx = 0;
        Vector3 pos;

        // loop through triangle array of indices
        for (int t = 0; t < triangles.Length; t++)
        {
            // current idx return from tris
            idx = triangles[t];
            // current pos of the vertex
            pos = vertices[idx];
            // if current pos is same as targetPt
            if (pos == targetPt)
            {
                // add to list
                relatedVertices.Add(idx);
                // if find connected vertices
                if (findConnected)
                {
                    // min
                    // - prevent running out of count
                    if (t == 0)
                    {
                        relatedVertices.Add(triangles[t + 1]);
                    }
                    // max 
                    // - prevent runnign out of count
                    if (t == triangles.Length - 1)
                    {
                        relatedVertices.Add(triangles[t - 1]);
                    }
                    // between 1 ~ max-1 
                    // - add idx from triangles before t and after t 
                    if (t > 0 && t < triangles.Length - 1)
                    {
                        relatedVertices.Add(triangles[t - 1]);
                        relatedVertices.Add(triangles[t + 1]);
                    }
                }
            }
        }
        // return compiled list of int
        return relatedVertices;
    }
    public void PullSimilarVertices(int index, Vector3 newPos, int[] triangles, Vector3[] vertices, ref GameObject parent)
    {
        Vector3 targetVertexPos = vertices[index]; //1
        List<int> relatedVertices = FindRelatedVertices(targetVertexPos, false, triangles, vertices); //2
        foreach (int i in relatedVertices) //3
        {
            vertices[i] = newPos;
        }
        parent.GetComponent<MeshFilter>().mesh.vertices = vertices; //4
        parent.GetComponent<MeshFilter>().mesh.RecalculateNormals();
    }
}
