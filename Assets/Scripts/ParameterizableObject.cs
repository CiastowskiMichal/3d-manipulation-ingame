using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class ParameterizableObject
{
    public int Id;
    public string Name;
    public Vector3 Position;
    public Vector3 Rotation;
    public Vector3 Scale;
    public Vector3[] vertices;
    public int[] triangles;
    public Vector2[] uv;
    public Color Albedo;
    public float Metallic;
    public float Smoothness;

    public int getId()
    {
        return this.Id;
    }

    public void setId(int Id)
    {
        this.Id = Id;
    }

    public string getName()
    {
        return this.Name;
    }

    public void setName(string Name)
    {
        this.Name = Name;
    }

    public Vector3 getPosition()
    {
        return this.Position;
    }

    public void setPosition(Vector3 Position)
    {
        this.Position = Position;
    }

    public Quaternion getRotation()
    {
        return Quaternion.Euler(this.Rotation);
    }

    public void setRotation(Vector3 Rotation)
    {
        this.Rotation = Rotation;
    }

    public Vector3 getScale()
    {
        return this.Scale;
    }

    public void setScale(Vector3 Scale)
    {
        this.Scale = Scale;
    }

    public Vector3[] getVertices()
    {
        return this.vertices;
    }

    public void setVertices(Vector3[] vertices)
    {
        this.vertices = vertices;
    }

    public int[] getTriangles()
    {
        return this.triangles;
    }

    public void setTriangles(int[] triangles)
    {
        this.triangles = triangles;
    }

    public Vector2[] getUv()
    {
        return this.uv;
    }

    public void setUv(Vector2[] uv)
    {
        this.uv = uv;
    }

    public Color getAlbedo()
    {
        return this.Albedo;
    }

    public void setAlbedo(Color Albedo)
    {
        this.Albedo = Albedo;
    }

    public float getMetallic()
    {
        return this.Metallic;
    }

    public void setMetallic(float Metallic)
    {
        this.Metallic = Metallic;
    }

    public float getSmoothness()
    {
        return this.Smoothness;
    }

    public void setSmoothness(float Smoothness)
    {
        this.Smoothness = Smoothness;
    }

}
