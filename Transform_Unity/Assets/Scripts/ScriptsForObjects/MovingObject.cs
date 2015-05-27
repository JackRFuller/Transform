using UnityEngine;
using System.Collections;

public class MovingObject : MonoBehaviour {

    private Vector3 localRotation;

    void OnCollisionStay(Collision other)
    {
        if (other.collider.tag == "Player")
            other.transform.parent = gameObject.transform.parent.transform;
    }


    void OnCollisionExit(Collision other)
    {
        if (other.collider.tag == "Player")
        {
            Quaternion localRotFromP = other.transform.localRotation * Quaternion.Inverse(gameObject.transform.parent.transform.rotation);
            other.transform.parent = null;
            other.transform.rotation = localRotFromP;
        }
    }
}
