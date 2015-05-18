using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TestLevel_LM : MonoBehaviour {

    
    bool StaffEvent = false;
    [SerializeField] Text StaffText;
    [SerializeField] GameObject Staff;
    [SerializeField] GameObject PlayerStaff;
    [SerializeField] GameObject[] Event1Doors;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (StaffEvent)
        {
            if (Input.GetKey("e"))
            {
                AddStaff();
                StaffEvent = false;
            }
        }
	
	}

    public void Events(int EventNumber)
    {
        switch (EventNumber)
        {
            case 1:
                Event1();
            break;
        }
    }

    void Event1()
    {
        StaffEvent = true;
        StaffText.enabled = true;
    }

    void AddStaff()
    {
        Staff.SetActive(false);
        PlayerStaff.SetActive(true);
        StaffText.enabled = false;

        foreach (GameObject Door in Event1Doors)
        {
            Door.GetComponent<Animation>().Play();
        }
    }
}
