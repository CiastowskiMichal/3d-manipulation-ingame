using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ListElementParentController : MonoBehaviour
{
    bool Visibility = true;
    [SerializeField]
    GameObject Panel;
    public GameObject Origin;
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<RectTransform>().sizeDelta = new Vector2(this.GetComponent<RectTransform>().sizeDelta.x, 20 + 20 * Panel.transform.childCount);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void HierarchyTree()
    {
        Visibility = !Visibility;
        if (Visibility)
        {
            foreach (Transform child in Panel.transform)
            {
                child.GetComponent<RectTransform>().sizeDelta = new Vector2(child.GetComponent<RectTransform>().sizeDelta.x, 20);
                child.GetComponentInChildren<Text>().rectTransform.sizeDelta = new Vector2(child.GetComponentInChildren<Text>().rectTransform.sizeDelta.x, 20);
                this.GetComponent<RectTransform>().sizeDelta = new Vector2(this.GetComponent<RectTransform>().sizeDelta.x, 20 + 20 * Panel.transform.childCount);
            }
        }
        else
        {
            foreach (Transform child in Panel.transform)
            {
                child.GetComponent<RectTransform>().sizeDelta = new Vector2(child.GetComponent<RectTransform>().sizeDelta.x, 0);
                child.GetComponentInChildren<Text>().rectTransform.sizeDelta = new Vector2(child.GetComponentInChildren<Text>().rectTransform.sizeDelta.x, 0);
                this.GetComponent<RectTransform>().sizeDelta = new Vector2(this.GetComponent<RectTransform>().sizeDelta.x, 20);
            }
        }
    }
    public void SetOriginGameObject(GameObject gameObject)
    {
        this.Origin = gameObject;
    }
    public void SendOriginToPanel()
    {
        GameObject.FindGameObjectWithTag("MeshOrigin").GetComponent<ContainerController>().SetOriginGameObject(Origin);
    }
}
