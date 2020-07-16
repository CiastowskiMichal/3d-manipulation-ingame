using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContainerController : MonoBehaviour
{
    [SerializeField]
    GameObject Origin;
    public InputField[] inputs = new InputField[9];
    Vector3 OriginPosition;
    Vector3 OriginRotation;
    Vector3 OriginScale;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SetOriginGameObject(GameObject gameObject)
    {
        this.Origin = gameObject;
        //Debug.Log(gameObject.transform.position);
        setInputs(gameObject);
    }
    void setInputs(GameObject gameObject)
    {
        inputs[0].text = gameObject.transform.position.x.ToString();
        inputs[1].text = gameObject.transform.position.y.ToString();
        inputs[2].text = gameObject.transform.position.z.ToString();
        inputs[3].text = gameObject.transform.rotation.eulerAngles.x.ToString();
        inputs[4].text = gameObject.transform.rotation.eulerAngles.y.ToString();
        inputs[5].text = gameObject.transform.rotation.eulerAngles.z.ToString();
        inputs[6].text = gameObject.transform.localScale.x.ToString();
        inputs[7].text = gameObject.transform.localScale.y.ToString();
        inputs[8].text = gameObject.transform.localScale.z.ToString();
        OriginPosition = gameObject.transform.position;
        OriginRotation = gameObject.transform.rotation.eulerAngles;
        OriginScale = gameObject.transform.localScale;
    }
    public void SetPositionX(InputField inputField)
    {
        if (Origin != null)
        {
            float number;
            if (float.TryParse(inputField.text, out number))
            {
                OriginPosition.x = number;
                setTransform(Origin);
            }
            else
            {
                inputField.text = OriginPosition.x.ToString();
            }
        }
    }
    public void SetPositionY(InputField inputField)
    {
        if (Origin != null)
        {
            float number;
            if (float.TryParse(inputField.text, out number))
            {
                OriginPosition.y = number;
                setTransform(Origin);
            }
            else
            {
                inputField.text = OriginPosition.y.ToString();
            }
        }
    }
    public void SetPositionZ(InputField inputField)
    {
        if (Origin != null)
        {
            float number;
            if (float.TryParse(inputField.text, out number))
            {
                OriginPosition.z = number;
                setTransform(Origin);
            }
            else
            {
                inputField.text = OriginPosition.z.ToString();
            }
        }
    }
    public void SetRotationX(InputField inputField)
    {
        if (Origin != null)
        {
            float number;
            if (float.TryParse(inputField.text, out number))
            {
                OriginRotation.x = number;
                setTransform(Origin);
            }
            else
            {
                inputField.text = OriginRotation.x.ToString();
            }
        }
    }
    public void SetRotationY(InputField inputField)
    {
        if (Origin != null)
        {
            float number;
            if (float.TryParse(inputField.text, out number))
            {
                OriginRotation.y = number;
                setTransform(Origin);
            }
            else
            {
                inputField.text = OriginRotation.y.ToString();
            }
        }
    }
    public void SetRotationZ(InputField inputField)
    {
        if (Origin != null)
        {
            float number;
            if (float.TryParse(inputField.text, out number))
            {
                OriginRotation.z = number;
                setTransform(Origin);
            }
            else
            {
                inputField.text = OriginRotation.z.ToString();
            }
        }
    }
    public void SetScaleX(InputField inputField)
    {
        if (Origin != null)
        {
            float number;
            if (float.TryParse(inputField.text, out number))
            {
                OriginScale.x = number;
                setTransform(Origin);
            }
            else
            {
                inputField.text = OriginScale.x.ToString();
            }
        }
    }
    public void SetScaleY(InputField inputField)
    {
        if (Origin != null)
        {
            float number;
            if (float.TryParse(inputField.text, out number))
            {
                OriginScale.y = number;
                setTransform(Origin);
            }
            else
            {
                inputField.text = OriginScale.y.ToString();
            }
        }
    }
    public void SetScaleZ(InputField inputField)
    {
        if (Origin != null)
        {
            float number;
            if (float.TryParse(inputField.text, out number))
            {
                OriginScale.z = number;
                setTransform(Origin);
            }
            else
            {
                inputField.text = OriginScale.z.ToString();
            }
        }
    }
    void setTransform(GameObject gameObject)
    {
        gameObject.transform.position = OriginPosition;
        gameObject.transform.rotation = Quaternion.Euler(OriginRotation);
        gameObject.transform.localScale = OriginScale;
    }
}
