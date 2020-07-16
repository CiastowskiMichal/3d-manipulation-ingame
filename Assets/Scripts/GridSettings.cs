using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridSettings : MonoBehaviour
{
    public enum Sizes : int
    {
        vsmall = 1,
        small = 2,
        medium = 4,
        big = 8,
        vbig = 16
    }
    [Header("Rozmiar Siatki")]
    public Sizes sizes = Sizes.medium;
    [Header("Kolor Siatki")]
    [Range(0, 1)]
    public float GridColor = 0.75f;
    public float GridWidth = 0.9f;
    private int GridSize = 2;
    private float PlaneSize = 2;
    private Vector3 Wersor = new Vector3(1, 1, 1);
    [SerializeField]
    Dropdown d;
    [SerializeField]
    Slider s;
    [SerializeField]
    Slider s2;

    //private Material material;

    // Start is called before the first frame update
    void Start()
    {
        if (s != null && d != null)
        {
            GridColor = s.value;
            GridWidth = s2.value;
            switch (sizes)
            {
                case Sizes.vsmall:
                    d.value = 0;
                    break;
                case Sizes.small:
                    d.value = 1;
                    break;
                case Sizes.medium:
                    d.value = 2;
                    break;
                case Sizes.big:
                    d.value = 3;
                    break;
                case Sizes.vbig:
                    d.value = 4;
                    break;
                default:
                    break;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Transform child in transform)
        {
            child.GetComponent<Renderer>().material.SetFloat("GridSize", GridSize);
            child.GetComponent<Renderer>().material.SetFloat("GridColor", GridColor);
            child.GetComponent<Renderer>().material.SetFloat("GridWidth", GridWidth);
        }
        transform.localScale = Wersor * GridSize * 0.1f;
    }
    public void SetSize(Dropdown dropdown)
    {
        switch (dropdown.value)
        {
            case 0:
                GridSize = (int)Sizes.vsmall;
                break;
            case 1:
                GridSize = (int)Sizes.small;
                break;
            case 2:
                GridSize = (int)Sizes.medium;
                break;
            case 3:
                GridSize = (int)Sizes.big;
                break;
            case 4:
                GridSize = (int)Sizes.vbig;
                break;
            default:
                break;
        }
    }
    public void SetBrightness(Slider slider)
    {
        GridColor = slider.value;
    }
    public void SetWidth(Slider slider)
    {
        GridWidth = slider.value;
    }
}
