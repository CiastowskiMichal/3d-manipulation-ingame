using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowSettings : MonoBehaviour
{
    public bool IsMinimized = false;
    private float height;
    private float baseHeight;
    // Start is called before the first frame update
    void Start()
    {
        height = GetComponent<RectTransform>().sizeDelta.y;
        baseHeight = height;
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsMinimized)
        {
            height = baseHeight;
        }
        else
        {
            height = 30;
        }

        GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Mathf.Lerp(GetComponent<RectTransform>().sizeDelta.y, height, 0.2f));
    }
    public void changeWindowHeight()
    {
        IsMinimized = !IsMinimized;
    }
}
