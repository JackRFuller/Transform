using UnityEngine;
using System.Collections;

public class RotateAroundPillar : MonoBehaviour {

    [SerializeField] GameObject pillar;
    bool isRotating = false;
    public Vector3 moveRotation;
    public float speed;
    Vector3 currRotation;
    Vector3 startRotation;
	// Use this for initialization
	void Start () {

        pillar = transform.parent.gameObject;
        startRotation = transform.eulerAngles;
	
	}
	
	// Update is called once per frame
	void Update () {

        if (isRotating)
        {
            Vector3 to = moveRotation;

            if (Vector3.Distance(transform.eulerAngles, to) > 0.01f)
            {
                transform.eulerAngles = Vector3.Lerp(transform.rotation.eulerAngles, to, speed * Time.deltaTime);
                currRotation = transform.eulerAngles;
            }
            else
            {
                transform.eulerAngles = to;
                isRotating = false;
                currRotation = to;
            }
        }
        else
        {
            Vector3 to = moveRotation;

            if (Vector3.Distance(transform.eulerAngles, startRotation) > 0.01f)
            {
                transform.eulerAngles = Vector3.Lerp(transform.rotation.eulerAngles, startRotation, speed * Time.deltaTime);
            }
            else
            {
                transform.eulerAngles = startRotation;
                isRotating = false;
            }
        }
	
	}

    void StartTrigger()
    {
        isRotating = true;
    }

    void StopTrigger()
    {
        isRotating = false;
    }
}
