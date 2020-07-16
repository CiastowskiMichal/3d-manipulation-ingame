using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshEdit : MonoBehaviour
{
    public Vector3[] vertices;
    public int[] triangles;
    [SerializeField]
    public GameObject vertexHandler;
    public List<Corner> corners = new List<Corner>();

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //GetComponent<MeshFilter>().mesh.vertices = vertices;
    }
    public List<Corner> CornerList(Vector3[] vs)
    {
        List<Vertex> Vector3List = new List<Vertex>();
        List<Corner> list = new List<Corner>();
        int counter = 0;
        foreach (Vector3 v in vs)
        {
            Vector3List.Add(new Vertex(counter, v));
            counter++;
        }
        List<Vertex> tempList = new List<Vertex>();
        tempList = Vector3List;

        while (tempList.Count > 0)
        {
            counter = 0;
            Vertex tempV = new Vertex(1, new Vector3(0, 0, 0));
            Corner crnr;
            crnr = new Corner();
            foreach (Vertex v in tempList)
            {
                if (VertexPresence(list, v) == -1)
                {
                    if (counter == 0)
                    {
                        crnr.AddVertexToCorner(v);
                        tempV = v;
                        list.Add(crnr);
                    }
                }
                counter++;
            }
            tempList.RemoveAt(0);
        }
        Debug.Log(list.Count);
        return list;
    }
    int VertexPresence(List<Corner> lc, Vertex v)
    {
        int presence = -1;
        foreach (Corner c in lc)
        {
            foreach (Vertex vertex in c.VertexList)
            {
                if (vertex.vector.x == v.vector.x && vertex.vector.y == v.vector.y && vertex.vector.z == v.vector.z)
                {
                    presence = lc.IndexOf(c);
                }
            }
        }
        return presence;
    }
    public void InstanceVertexEditMode()
    {
        vertices = transform.GetComponent<MeshFilter>().mesh.vertices;
        triangles = GetComponent<MeshFilter>().mesh.triangles;
        corners = CornerList(vertices);
        int counter = 0;
        foreach (Corner c in corners)
        {
            GameObject instance = Instantiate(vertexHandler,this.transform);
            instance.transform.localPosition = c.GetPosition();
            instance.GetComponent<VertexUpdate>().SetParent(this.gameObject);
            instance.GetComponent<VertexUpdate>().SetCorner(c);
            instance.gameObject.name = "VertexPoint_" + counter;
            counter++;
        }
    }
    public void DeleteVertexEditMode()
    {
        foreach(GameObject gameObject in GameObject.FindObjectsOfType<GameObject>())
        {
            if(gameObject.name.Contains("VertexPoint"))
            {
                Destroy(gameObject.gameObject);
            }
        }
    }
}
