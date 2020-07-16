using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadSavePanelController : MonoBehaviour
{
    [SerializeField]
    Text label;
    [SerializeField]
    public InputField inputField;
    [SerializeField]
    public Button b1;
    [SerializeField]
    Button b2;
    // Start is called before the first frame update
    void Start()
    {
        b2.onClick.AddListener(DestroyPanel);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void DestroyPanel()
    {
        Destroy(this.gameObject);
    }
    public void setLabel(string name)
    {
        this.label.text = name;
    }
}
