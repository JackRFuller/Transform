using UnityEngine;
using System.Collections;

public class EventTrigger : MonoBehaviour {

    public int EventNumber = 0;
    public TestLevel_LM LevelManager;

	// Use this for initialization
	void Start () {

        LevelManager = GameObject.Find("LevelManager").GetComponent<TestLevel_LM>();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "EventZone")
        {
            EventNumber++;
            LevelManager.Events(EventNumber);
            col.gameObject.GetComponent<Collider>().enabled = false;
        }
    }
}
