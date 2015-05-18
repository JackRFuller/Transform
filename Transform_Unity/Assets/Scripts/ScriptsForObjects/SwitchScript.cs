using UnityEngine;
using System.Collections;

public class SwitchScript : MonoBehaviour {

    public GameObject Event;
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
                if (!isTriggered)
                    SwitchOn();
                else
                    SwitchOff();

                isTriggered = !isTriggered;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (!isTriggered)
                    SwitchOn();
                else
                    SwitchOff();

                isTriggered = !isTriggered;
            }
        }
    }
    void SwitchOn()
    {
        Event.BroadcastMessage("StartTrigger", SendMessageOptions.DontRequireReceiver);
    }

    void SwitchOff()
    {
        Event.BroadcastMessage("StopTrigger", SendMessageOptions.DontRequireReceiver);
    }
}
