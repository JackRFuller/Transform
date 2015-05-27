using UnityEngine;
using System.Collections;

public class PlatformSwitch : MonoBehaviour {

    private bool active;
    [SerializeField] GameObject Event;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Scalable")
        {
            Event.SendMessage("StartTrigger", SendMessageOptions.DontRequireReceiver);
            active = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Scalable")
        {
            Event.SendMessage("StopTrigger", SendMessageOptions.DontRequireReceiver);
            active = false;
        }
    }
}
