using UnityEngine;
using System.Collections;

public class PlatformSwitch : MonoBehaviour {

    private bool active;
    [SerializeField] GameObject[] Event;
    [SerializeField] float[] DelayBetweenEvents;

    private IEnumerator wait()
    {
        for (int i = 0; i < Event.Length; i++)
        {
            Event[i].BroadcastMessage("StartTrigger", SendMessageOptions.DontRequireReceiver);
            yield return new WaitForSeconds(DelayBetweenEvents[i]);
        }
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Scalable")
        {
            StartCoroutine(wait());
            active = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Scalable")
        {
            for (int i = 0; i < Event.Length; i ++ )
                Event[i].SendMessage("StopTrigger", SendMessageOptions.DontRequireReceiver);

            active = false;
        }
    }
}
