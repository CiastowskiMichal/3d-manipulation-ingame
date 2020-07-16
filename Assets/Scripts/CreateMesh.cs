using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateMesh : MonoBehaviour
{
    [SerializeField]
    GameObject Cube;
    [SerializeField]
    GameObject ListElement;
        [SerializeField]
    GameObject ListElementParent;
    [SerializeField]
    GameObject ListParent;
    [SerializeField]
    GameObject VertexHandler;
    [SerializeField]
    Material DefaultMaterial;
    [HideInInspector]
    public Vector3[] vertices;
    Vector2[] uv;
    int[] triangles;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void InstantiateListElement(GameObject Model)
    {
        GameObject gameObject = Instantiate(ListElement);
        gameObject.transform.SetParent(ListParent.transform, false);
        ListElementController listElementController = gameObject.GetComponent<ListElementController>();
        listElementController.setModel(Model);
        gameObject.GetComponentInChildren<Text>().text = Model.name;
    }
    public GameObject InstantiateListElementParent(string name, GameObject Origin)
    {
        GameObject gameObject = Instantiate(ListElementParent);
        gameObject.transform.SetParent(ListParent.transform, false);
        gameObject.GetComponentInChildren<Text>().text = GenerateMeshName(name);
        gameObject.GetComponent<ListElementParentController>().SetOriginGameObject(Origin);
        return gameObject;
    }
        void InstantiateImportedListElementIntoParent(GameObject Model, GameObject Parent)
    {
        GameObject gameObject = Instantiate(ListElement);
        gameObject.transform.SetParent(Parent.transform, false);
        ListElementController listElementController = gameObject.GetComponent<ListElementController>();
        listElementController.setModel(Model);
        gameObject.GetComponentInChildren<Text>().text = Model.name;
    }
    public void CreateCube(GameObject Model)
    {
        Mesh mesh = new Mesh();
        mesh.vertices = Model.GetComponent<MeshFilter>().sharedMesh.vertices;
        mesh.uv = Model.GetComponent<MeshFilter>().sharedMesh.uv;
        mesh.triangles = Model.GetComponent<MeshFilter>().sharedMesh.triangles;
        mesh.RecalculateNormals();
        GameObject gameObject = new GameObject(GenerateMeshName(Model.name), typeof(MeshFilter), typeof(MeshRenderer), typeof(MeshEdit));
        gameObject.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
        gameObject.transform.localScale = new Vector3(1, 1, 1);
        gameObject.GetComponent<MeshFilter>().mesh = mesh;
        gameObject.GetComponent<MeshRenderer>().material = DefaultMaterial;
        gameObject.GetComponent<MeshEdit>().vertexHandler = VertexHandler;
        InstantiateListElement(gameObject);
    }
    public void CopyModyfiedMesh(GameObject Model)
    {
        Mesh mesh = new Mesh();
        mesh.vertices = Model.GetComponent<MeshFilter>().sharedMesh.vertices;
        mesh.uv = Model.GetComponent<MeshFilter>().sharedMesh.uv;
        mesh.triangles = Model.GetComponent<MeshFilter>().sharedMesh.triangles;
        mesh.RecalculateNormals();
        GameObject gameObject = new GameObject(GenerateMeshName(Model.name), typeof(MeshFilter), typeof(MeshRenderer), typeof(MeshEdit));
        gameObject.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
        gameObject.GetComponent<MeshFilter>().mesh = mesh;
        gameObject.GetComponent<MeshRenderer>().material = Model.GetComponent<MeshRenderer>().material;
        gameObject.transform.localScale = Model.transform.localScale;
        gameObject.transform.position = Model.transform.position;
        gameObject.transform.rotation = Model.transform.rotation;
        gameObject.GetComponent<MeshEdit>().vertexHandler = VertexHandler;
        InstantiateListElement(gameObject);
    }
    public void ReconstructMeshFromObject(ParameterizableObject parameterizable, GameObject Parent, GameObject OriginObject)
    {
        Mesh mesh = new Mesh();
        mesh.vertices = parameterizable.getVertices();
        mesh.uv = parameterizable.getUv();
        mesh.triangles = parameterizable.getTriangles();
        mesh.RecalculateNormals();
        GameObject gameObject = new GameObject(parameterizable.getName(), typeof(MeshFilter), typeof(MeshRenderer), typeof(MeshEdit));
        gameObject.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
        gameObject.GetComponent<MeshFilter>().mesh = mesh;
        gameObject.GetComponent<MeshRenderer>().material = DefaultMaterial;
        gameObject.GetComponent<MeshRenderer>().material.SetColor("Albedo", parameterizable.getAlbedo());
        gameObject.GetComponent<MeshRenderer>().material.SetFloat("Metallic", parameterizable.getMetallic());
        gameObject.GetComponent<MeshRenderer>().material.SetFloat("Smoothness", parameterizable.getSmoothness());
        gameObject.transform.localScale = parameterizable.getScale();
        gameObject.transform.position = parameterizable.getPosition();
        gameObject.transform.rotation = parameterizable.getRotation();
        gameObject.GetComponent<MeshEdit>().vertexHandler = VertexHandler;
        gameObject.transform.SetParent(OriginObject.transform,false);
        InstantiateImportedListElementIntoParent(gameObject, Parent);
    }
    public void CreateImportedObject(Mesh mesh)
    {
        mesh.RecalculateNormals();
        GameObject gameObject = new GameObject(GenerateMeshName("Imported"), typeof(MeshFilter), typeof(MeshRenderer), typeof(MeshEdit));
        gameObject.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
        gameObject.transform.localScale = new Vector3(1, 1, 1);
        gameObject.GetComponent<MeshFilter>().mesh = mesh;
        gameObject.GetComponent<MeshRenderer>().material = DefaultMaterial;
        gameObject.GetComponent<MeshEdit>().vertexHandler = VertexHandler;
        InstantiateListElement(gameObject);
    }
    string GenerateMeshName(string name)
    {
        return name + "_" + ListParent.transform.childCount;
    }
}
