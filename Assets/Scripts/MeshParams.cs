using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MeshParams : MonoBehaviour
{
    public enum Axis
    {
        x,
        y,
        z
    };
    public GameObject ModifyMesh;
    public ListElementController listElementController;
    [SerializeField]
    GameObject GizmoPrefab;
    private GameObject Gizmo;
    public Vector3 ObjectPosition;
    public Vector3 ObjectRotation;
    public Vector3 ObjectScale;
    public float Metallic = 0.5f;
    public float Smoothness = 0.5f;
    public Color Albedo = new Color(1, 1, 1, 1);
    public float Highlight;
    [SerializeField]
    Image Ialbedo;
    [SerializeField]
    Image Imetallic;
    [SerializeField]
    Image Ismoothness;
    [SerializeField]
    Slider[] sliders = new Slider[5];
    [SerializeField]
    InputField[] InputPosition = new InputField[3];
    [SerializeField]
    InputField[] InputRotation = new InputField[3];
    [SerializeField]
    InputField[] InputScale = new InputField[3];
    private bool IsEditing = false;



    // Start is called before the first frame update
    void Start()
    {
        setSliders();
        if (Ialbedo != null && Imetallic != null && Ismoothness != null)
        {
            Imetallic.color = new Vector4(Metallic, Metallic, Metallic, 1);
            Ismoothness.color = new Vector4(Smoothness, Smoothness, Smoothness, 1);
            Ialbedo.color = new Vector4(Albedo.r, Albedo.g, Albedo.b, 1);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Ialbedo != null && Imetallic != null && Ismoothness != null)
        {
            Imetallic.color = new Vector4(Metallic, Metallic, Metallic, 1);
            Ismoothness.color = new Vector4(Smoothness, Smoothness, Smoothness, 1);
            Ialbedo.color = new Vector4(Albedo.r, Albedo.g, Albedo.b, 1);
        }
        if (ModifyMesh != null)
        {
            setMaterial(ModifyMesh);
        }
        MouseRayCasting();
    }
    void MouseRayCasting()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit) && Input.GetMouseButton(0) && !Input.GetButton("Option"))
        {
            switch (hit.transform.name)
            {
                case "AxisX":
                    ChangeObjectPosition(Time.deltaTime, Axis.x);
                    break;
                case "AxisY":
                    ChangeObjectPosition(Time.deltaTime, Axis.y);
                    break;
                case "AxisZ":
                    ChangeObjectPosition(Time.deltaTime, Axis.z);
                    break;
                default:
                    break;
            }
        }
        if (Physics.Raycast(ray, out hit) && Input.GetMouseButton(1) && !Input.GetButton("Option"))
        {
            switch (hit.transform.name)
            {
                case "AxisX":
                    ChangeObjectPosition(-1 * Time.deltaTime, Axis.x);
                    break;
                case "AxisY":
                    ChangeObjectPosition(-1 * Time.deltaTime, Axis.y);
                    break;
                case "AxisZ":
                    ChangeObjectPosition(-1 * Time.deltaTime, Axis.z);
                    break;
                default:
                    break;
            }
        }
    }
    public void setMetallic(Slider slider)
    {
        Metallic = slider.value;
    }
    public void setSmoothness(Slider slider)
    {
        Smoothness = slider.value;
    }
    public void setRColor(Slider slider)
    {
        Albedo.r = slider.value;
    }
    public void setGColor(Slider slider)
    {
        Albedo.g = slider.value;
    }
    public void setBColor(Slider slider)
    {
        Albedo.b = slider.value;
    }
    public void setInputPositionX(InputField inputField)
    {
        if (ModifyMesh != null)
        {
            float number;
            if (float.TryParse(inputField.text, out number))
            {
                ObjectPosition.x = number;
                setTransform(ModifyMesh);
            }
            else
            {
                inputField.text = ObjectPosition.x.ToString();
            }
        }
    }
    public void setInputPositionY(InputField inputField)
    {
        if (ModifyMesh != null)
        {
            float number;
            if (float.TryParse(inputField.text, out number))
            {
                ObjectPosition.y = number;
                setTransform(ModifyMesh);
            }
            else
            {
                inputField.text = ObjectPosition.y.ToString();
            }
        }
    }
    public void setInputPositionZ(InputField inputField)
    {
        if (ModifyMesh != null)
        {
            float number;
            if (float.TryParse(inputField.text, out number))
            {
                ObjectPosition.z = number;
                setTransform(ModifyMesh);
            }
            else
            {
                inputField.text = ObjectPosition.z.ToString();
            }
        }
    }
    public void setInputRotationX(InputField inputField)
    {
        if (ModifyMesh != null)
        {
            float number;
            if (float.TryParse(inputField.text, out number))
            {
                ObjectRotation.x = number;
                setTransform(ModifyMesh);
            }
            else
            {
                inputField.text = ObjectRotation.x.ToString();
            }
        }
    }
    public void setInputRotationY(InputField inputField)
    {
        if (ModifyMesh != null)
        {
            float number;
            if (float.TryParse(inputField.text, out number))
            {
                ObjectRotation.y = number;
                setTransform(ModifyMesh);
            }
            else
            {
                inputField.text = ObjectRotation.y.ToString();
            }
        }
    }
    public void setInputRotationZ(InputField inputField)
    {
        if (ModifyMesh != null)
        {
            float number;
            if (float.TryParse(inputField.text, out number))
            {
                ObjectRotation.z = number;
                setTransform(ModifyMesh);
            }
            else
            {
                inputField.text = ObjectRotation.z.ToString();
            }
        }
    }
    public void setInputScaleX(InputField inputField)
    {
        if (ModifyMesh != null)
        {
            float number;
            if (float.TryParse(inputField.text, out number))
            {
                ObjectScale.x = number;
                setTransform(ModifyMesh);
            }
            else
            {
                inputField.text = ObjectScale.x.ToString();
            }
        }
    }
    public void setInputScaleY(InputField inputField)
    {
        if (ModifyMesh != null)
        {
            float number;
            if (float.TryParse(inputField.text, out number))
            {
                ObjectScale.y = number;
                setTransform(ModifyMesh);
            }
            else
            {
                inputField.text = ObjectScale.y.ToString();
            }
        }
    }
    public void setInputScaleZ(InputField inputField)
    {
        if (ModifyMesh != null)
        {
            float number;
            if (float.TryParse(inputField.text, out number))
            {
                ObjectScale.z = number;
                setTransform(ModifyMesh);
            }
            else
            {
                inputField.text = ObjectScale.z.ToString();
            }
        }
    }
    void setSliders()
    {
        sliders[0].value = Albedo.r;
        sliders[1].value = Albedo.g;
        sliders[2].value = Albedo.b;
        sliders[3].value = Metallic;
        sliders[4].value = Smoothness;
    }
    void setSlidersFromGameObject(GameObject gameObject)
    {
        sliders[0].value = gameObject.GetComponent<Renderer>().material.GetColor("Albedo").r;
        sliders[1].value = gameObject.GetComponent<Renderer>().material.GetColor("Albedo").g;
        sliders[2].value = gameObject.GetComponent<Renderer>().material.GetColor("Albedo").b;
        sliders[3].value = gameObject.GetComponent<Renderer>().material.GetFloat("Metallic");
        sliders[4].value = gameObject.GetComponent<Renderer>().material.GetFloat("Smoothness");
        InputPosition[0].text = gameObject.transform.localPosition.x.ToString();
        InputPosition[1].text = gameObject.transform.localPosition.y.ToString();
        InputPosition[2].text = gameObject.transform.localPosition.z.ToString();
        InputRotation[0].text = gameObject.transform.localRotation.eulerAngles.x.ToString();
        InputRotation[1].text = gameObject.transform.localRotation.eulerAngles.y.ToString();
        InputRotation[2].text = gameObject.transform.localRotation.eulerAngles.z.ToString();
        InputScale[0].text = gameObject.transform.localScale.x.ToString();
        InputScale[1].text = gameObject.transform.localScale.y.ToString();
        InputScale[2].text = gameObject.transform.localScale.z.ToString();
        ObjectPosition = gameObject.transform.localPosition;
        ObjectRotation = gameObject.transform.localRotation.eulerAngles;
        ObjectScale = gameObject.transform.localScale;
    }
    public void setGameObject(GameObject Model)
    {
        ModifyMesh = Model;
        setSlidersFromGameObject(Model);
        SearchAndDestroyGizmo();
        Gizmo = Instantiate(GizmoPrefab, Model.transform.position, ModifyMesh.transform.rotation);
    }
    public void setListElement(ListElementController listElement)
    {
        this.listElementController = listElement;
    }
    void setMaterial(GameObject gameObject)
    {
        gameObject.GetComponent<Renderer>().material.SetColor("Albedo", new Vector4(Albedo.r, Albedo.g, Albedo.b, 1));
        gameObject.GetComponent<Renderer>().material.SetFloat("Metallic", Metallic);
        gameObject.GetComponent<Renderer>().material.SetFloat("Smoothness", Smoothness);
    }
    void setTransform(GameObject gameObject)
    {
        gameObject.transform.localPosition = ObjectPosition;
        gameObject.transform.localRotation = Quaternion.Euler(ObjectRotation);
        gameObject.transform.localScale = ObjectScale;
        Gizmo.transform.position = gameObject.transform.position;
    }
    public void updateInputPosition()
    {
        InputPosition[0].text = ObjectPosition.x.ToString();
        InputPosition[1].text = ObjectPosition.y.ToString();
        InputPosition[2].text = ObjectPosition.z.ToString();
    }
    public void updateModelPosition()
    {
        setTransform(ModifyMesh);
    }
    public void changeObjectPositionX(string s)
    {
        switch (s)
        {
            case "+":
                ObjectPosition.x += 0.1f;
                break;

            case "-":
                ObjectPosition.x -= 0.1f;
                break;

            default:
                break;
        }
        updateInputPosition();
        updateModelPosition();
    }
    public void changeObjectPositionY(string s)
    {
        switch (s)
        {
            case "+":
                ObjectPosition.y += 0.1f;
                break;

            case "-":
                ObjectPosition.y -= 0.1f;
                break;

            default:
                break;
        }
        updateInputPosition();
        updateModelPosition();
    }
    public void changeObjectPositionZ(string s)
    {
        switch (s)
        {
            case "+":
                ObjectPosition.z += 0.1f;
                break;

            case "-":
                ObjectPosition.z -= 0.1f;
                break;

            default:
                break;
        }
        updateInputPosition();
        updateModelPosition();
    }
    void ChangeObjectPosition(float value, Axis axis)
    {
        switch (axis)
        {
            case Axis.x:
                ObjectPosition.x += value;
                break;
            case Axis.y:
                ObjectPosition.y += value;
                break;
            case Axis.z:
                ObjectPosition.z += value;
                break;
            default:
                break;
        }
        updateInputPosition();
        updateModelPosition();
    }
    public void CopyMesh()
    {
        if (ModifyMesh != null)
        {
            GameObject.FindGameObjectWithTag("BasicMeshes").GetComponent<CreateMesh>().CopyModyfiedMesh(ModifyMesh);
        }
    }
    public void CenterCameraOnObject()
    {
        if (ModifyMesh != null)
        {
            GameObject.FindGameObjectWithTag("CameraPivot").GetComponent<CameraController>().CenterCameraOnObject(ModifyMesh);
        }
    }
    public void DeleteObject()
    {
        if (ModifyMesh != null)
        {
            SearchAndDestroyGizmo();
            listElementController.DeleteObjectFromList();
        }
    }
    private void SearchAndDestroyGizmo()
    {
        GameObject[] gameObjects = FindObjectsOfType<GameObject>();
        foreach (GameObject gameObject in gameObjects)
        {
            if (gameObject.name.Contains("Gizmo"))
            {
                Destroy(gameObject.gameObject);
            }
        }
    }
    public void ShowEditMode()
    {
        IsEditing = !IsEditing;
        if (IsEditing)
        {
            ModifyMesh.GetComponent<MeshEdit>().InstanceVertexEditMode();
        }
        else
        {
            ModifyMesh.GetComponent<MeshEdit>().DeleteVertexEditMode();
        }
    }
}
