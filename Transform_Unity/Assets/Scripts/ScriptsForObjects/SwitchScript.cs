﻿using UnityEngine;
using System.Collections;

public class SwitchScript : MonoBehaviour {

    public GameObject[] Events;
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
        
        foreach(GameObject Event in Events)
        {
            Event.BroadcastMessage("StartTrigger", SendMessageOptions.DontRequireReceiver);
        }
       
    }

    void SwitchOff()
    {
        foreach(GameObject Event in Events)
        {
            Event.BroadcastMessage("StopTrigger", SendMessageOptions.DontRequireReceiver);
        }
        
    }
}
