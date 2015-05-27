using UnityEngine;
using System.Collections;

public class RotateAroundPillar : MonoBehaviour {

    public bool RotateBack;
    bool isRotating = false;
    public Vector3[] moveRotation;
    public float speed;
    Vector3 currRotation;
    Vector3 startRotation;
    int i = 0;
    private float rotateTime = 1f;
    private float currRotateTime;
	// Use this for initialization
	void Start () {

        startRotation = transform.eulerAngles;
	
	}
	
	// Update is called once per frame
	void Update () {

        if (isRotating)
        {
            Vector3 to = moveRotation[i];
            currRotateTime += Time.deltaTime;

            if (Vector3.Distance(transform.eulerAngles, to) > 0.01f)
            {
                float perc = currRotateTime / rotateTime;
                transform.eulerAngles = Vector3.Lerp(transform.rotation.eulerAngles, to, perc);
                currRotation = transform.eulerAngles;
            }
            else
            {
                transform.eulerAngles = to;
                isRotating = false;
                currRotation = to;
                currRotateTime = 0;

                i++;
                if (i > (moveRotation.Length - 1))
                    i = 0;
            }
        }
        //else
        //{
        //    if (RotateBack)
        //    {
        //        if (Vector3.Distance(transform.eulerAngles, startRotation) > 0.01f)
        //        {
        //            transform.eulerAngles = Vector3.Lerp(transform.rotation.eulerAngles, startRotation, speed * Time.deltaTime);
        //        }
        //        else
        //        {
        //            transform.eulerAngles = startRotation;
        //            isRotating = false;
        //        }
        //    }
        //}	
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
