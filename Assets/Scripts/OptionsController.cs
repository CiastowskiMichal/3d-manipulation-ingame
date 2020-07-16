using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
    [SerializeField] Material material;
    [SerializeField]
    GameObject ListParent;
    [SerializeField]
    GameObject LoadSavePanel;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }
    public void LoadProject(string name)
    {
        if (Directory.Exists(Application.dataPath) && File.Exists(Application.dataPath + "/" + name + ".json"))
        {
            GameObject importOrigin = new GameObject("importOrigin");
            GameObject ListElementParent = GameObject.FindGameObjectWithTag("BasicMeshes").GetComponent<CreateMesh>().InstantiateListElementParent(name, importOrigin);
            string load = File.ReadAllText(Application.dataPath + "/" + name + ".json");
            ParameterizableObjectList parameterizableObjectList = new ParameterizableObjectList();
            parameterizableObjectList = JsonUtility.FromJson<ParameterizableObjectList>(load);
            foreach (ParameterizableObject parameterizable in parameterizableObjectList.ParameterizableObjects)
            {
                GameObject.FindGameObjectWithTag("BasicMeshes").GetComponent<CreateMesh>().ReconstructMeshFromObject(parameterizable, ListElementParent.GetComponentInChildren<VerticalLayoutGroup>().transform.gameObject, importOrigin);
            }
        }
    }
    public void ImportModel()
    {
        if (Directory.Exists(Application.dataPath) && File.Exists(Application.dataPath + "/Model.obj"))
        {
            Mesh mesh = new Mesh();
            ObjImporter objImporter = new ObjImporter();
            mesh = objImporter.ImportFile(Application.dataPath + "/Model.obj");
            GameObject.FindGameObjectWithTag("BasicMeshes").GetComponent<CreateMesh>().CreateImportedObject(mesh);
        }

    }
    public void SaveProject(string name)
    {
        ParameterizableObject parameterizable = new ParameterizableObject();
        ParameterizableObjectList parameterizableObjectList = new ParameterizableObjectList();
        int counter = 0;
        foreach (MeshEdit Model in GameObject.FindObjectsOfType<MeshEdit>())
        {
            Debug.Log(counter);
            parameterizable = new ParameterizableObject();
            parameterizable.setAlbedo(Model.gameObject.GetComponent<MeshRenderer>().material.GetColor("Albedo"));
            parameterizable.setMetallic(Model.gameObject.GetComponent<MeshRenderer>().material.GetFloat("Metallic"));
            parameterizable.setSmoothness(Model.gameObject.GetComponent<MeshRenderer>().material.GetFloat("Smoothness"));
            parameterizable.setPosition(Model.transform.position);
            parameterizable.setRotation(Model.transform.rotation.eulerAngles);
            parameterizable.setScale(Model.transform.localScale);
            parameterizable.setVertices(Model.GetComponent<MeshFilter>().mesh.vertices);
            parameterizable.setTriangles(Model.GetComponent<MeshFilter>().mesh.triangles);
            parameterizable.setUv(Model.GetComponent<MeshFilter>().mesh.uv);
            parameterizable.setId(counter);
            parameterizable.setName(Model.transform.name);
            parameterizableObjectList.ParameterizableObjects.Add(parameterizable);
            counter++;
        }
        string json = JsonUtility.ToJson(parameterizableObjectList, true);
        File.WriteAllText(Application.dataPath + "/" + name + ".json", json);
    }
    public void ExportModel()
    {
        MeshEdit[] meshEdits = GameObject.FindObjectsOfType<MeshEdit>();
        CombineInstance[] combine = new CombineInstance[meshEdits.Length];
        for (int i = 0; i < meshEdits.Length; i++)
        {
            combine[i].mesh = meshEdits[i].gameObject.GetComponent<MeshFilter>().sharedMesh;
            combine[i].transform = meshEdits[i].gameObject.GetComponent<MeshFilter>().transform.localToWorldMatrix;
        }
        Mesh mesh = new Mesh();
        mesh.CombineMeshes(combine);
        GameObject gameObject = new GameObject("tempMesh", typeof(MeshFilter), typeof(MeshRenderer));
        gameObject.GetComponent<MeshFilter>().mesh = mesh;
        string obj = ObjExporter.MeshToString(gameObject.GetComponent<MeshFilter>());
        File.WriteAllText(Application.dataPath + "/Model.obj", obj);
        Destroy(gameObject);
    }
    public void ExitApp()
    {
        Application.Quit();
    }
    string GenerateMeshName(string name)
    {
        return name + "_" + ListParent.transform.childCount;
    }
    public void setSave()
    {
        GameObject gameObject = Instantiate(LoadSavePanel);
        gameObject.transform.SetParent(GameObject.FindGameObjectWithTag("MainCanvas").transform, false);
        gameObject.GetComponent<LoadSavePanelController>().setLabel("Zapisz jako...");
        gameObject.GetComponent<LoadSavePanelController>().b1.onClick.AddListener(delegate { SaveProject(gameObject.GetComponent<LoadSavePanelController>().inputField.text); });
    }
    public void SetLoad()
    {
        GameObject gameObject = Instantiate(LoadSavePanel);
        gameObject.transform.SetParent(GameObject.FindGameObjectWithTag("MainCanvas").transform, false);
        gameObject.GetComponent<LoadSavePanelController>().setLabel("Wczytaj plik...");
        gameObject.GetComponent<LoadSavePanelController>().b1.onClick.AddListener(delegate { LoadProject(gameObject.GetComponent<LoadSavePanelController>().inputField.text); });
    }
}
