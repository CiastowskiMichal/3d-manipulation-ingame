using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corner
{
    int Id;
    public List<Vertex> VertexList = new List<Vertex>();
    public void AddVertexToCorner(Vertex v)
    {
        VertexList.Add(v);
        Id = v.Id;
    }
    public Vector3 GetPosition()
    {
        return VertexList[0].vector;
    }
    public int GetId()
    {
        return Id;
    }
    public void SetId(int id)
    {
        this.Id = id;
    }
}