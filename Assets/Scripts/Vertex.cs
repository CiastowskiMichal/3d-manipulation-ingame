using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vertex {
    public Vertex(int id, Vector3 v)
    {
        this.Id = id;
        this.vector = v;
    }
    public int Id;
    public Vector3 vector;
    
}