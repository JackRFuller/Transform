using UnityEngine;
using System.Collections;

public class PlayerAction : MonoBehaviour {
    

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100))
            {
                Debug.DrawLine(ray.origin, hit.point,Color.green);
                if (hit.collider.tag == "Scalable")
                {
                    hit.collider.gameObject.GetComponent<ScaleObject>().IncreaseObjectSize();
                }
                
            }
        }
        if (Input.GetMouseButton(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100))
            {
                Debug.DrawLine(ray.origin, hit.point, Color.red);
                if (hit.collider.tag == "Scalable")
                {
                    hit.collider.gameObject.GetComponent<ScaleObject>().DecreaseObjectSize();
                    
                }

            }
        }
	
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "DeadZone")
        {
            GameObject.Find("LevelManager").GetComponent<LevelManager>().Restart();
        }
        
    }
}
