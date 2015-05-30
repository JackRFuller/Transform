using UnityEngine;
using System.Collections;

public abstract class EventsManager
{
    public delegate void Reset();
    public static event Reset OnReset;


    public static void InitReset()
    {
        EventsManager.OnReset();
    }
}
