using UnityEngine;
using System.Collections;

public class SwitchScript : MonoBehaviour {

    public GameObject[] Event;
    public float[] DelayBetweenEvents;
    [SerializeField] bool TwoStateSwitch;
    private GameObject player;
    bool isTriggered;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (Vector3.Distance(player.transform.position, transform.position) < 4)
        {
            PlayerInput();
        }
    }


    private void PlayerInput()
    {
        if (RigidbodyFirstPersonController.ControllerInUse)
        {
            if (Input.GetButtonDown("X"))
            {
                if (TwoStateSwitch)
                {
                    if (!isTriggered)
                        SwitchOn();
                    else
                        SwitchOff();

                    isTriggered = !isTriggered;
                }
                else
                {
                    SwitchOn();
                }
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (TwoStateSwitch)
                {
                    if (!isTriggered)
                        SwitchOn();
                    else
                        SwitchOff();

                    isTriggered = !isTriggered;
                }
                else
                {
                    SwitchOn();
                }
            }
        }
    }


    void SwitchOn()
    {
        StartCoroutine(wait());
    }

    private IEnumerator wait()
    {
        for (int i = 0; i < Event.Length; i++ )
        {
            Event[i].BroadcastMessage("StartTrigger", SendMessageOptions.DontRequireReceiver);
            yield return new WaitForSeconds(DelayBetweenEvents[i]);
        }      
    }


    void SwitchOff()
    {
        for (int i = 0; i < Event.Length; i++)
            Event[i].BroadcastMessage("StopTrigger", SendMessageOptions.DontRequireReceiver);
    }

    private void Reset()
    {
        isTriggered = false;
    }
}
