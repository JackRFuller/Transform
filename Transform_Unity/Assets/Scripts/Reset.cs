using UnityEngine;
using System.Collections;

public class Reset : MonoBehaviour {

    private  Vector3 rotation;
    private  Vector3 scale;
    private Vector3 position;
    private  Material startColour;

    void Start()
    {
        if (transform.parent == null)
        {
            rotation = transform.eulerAngles;
            scale = transform.localScale;
            position = transform.position;
        }
        else
        {
            rotation = transform.parent.transform.localScale;
            scale = transform.parent.transform.localScale;
            position = transform.parent.transform.localPosition;
        }

        EventsManager.OnReset += ResetTransform;

    }

    private void ResetTransform()
    {
        if (transform.parent == null)
        {
            transform.eulerAngles = rotation;
            transform.localScale = scale;
            transform.position = position;
        }
        else
        {
            transform.parent.transform.localEulerAngles = rotation;
            transform.parent.transform.localScale = scale;
            transform.parent.transform.localPosition = position;
        }

        transform.SendMessage("Reset", SendMessageOptions.DontRequireReceiver);
    }
}
