using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class ListElementController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    GameObject Model;
    [SerializeField]
    GameObject meshParams;
    private bool deleteOrder = false;
    [SerializeField]
    GameObject ListParent;
    // Start is called before the first frame update
    void Start()
    {
        Model.GetComponent<MeshRenderer>().material.SetFloat("Highlight", 0);
        ListParent = transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void updateMeshParams()
    {
        meshParams.GetComponent<MeshParams>().setGameObject(Model);
        meshParams.GetComponent<MeshParams>().setListElement(this);
        WhenSelected();
    }
    public void setModel(GameObject gameObject)
    {
        setMeshParams();
        Model = gameObject;
    }
    public void setMeshParams()
    {
        meshParams = GameObject.FindGameObjectWithTag("ObjectParams");
    }
    public void DeleteObjectFromList()
    {
        Destroy(Model.gameObject);
        Destroy(this.gameObject);
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        Model.GetComponent<MeshRenderer>().material.SetFloat("Highlight", 1);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        Model.GetComponent<MeshRenderer>().material.SetFloat("Highlight", 0);
    }
    public void WhenSelected()
    {
        foreach (GameObject child in GameObject.FindGameObjectsWithTag("ListElement"))
        {
            child.GetComponent<Button>().interactable = true;
        }
        GetComponent<Button>().interactable = false;
    }
}
