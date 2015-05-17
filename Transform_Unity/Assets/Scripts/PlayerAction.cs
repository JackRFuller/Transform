using UnityEngine;
using System.Collections;

public class PlayerAction : MonoBehaviour {

    private bool rtCanShoot;
    private bool ltCanShoot;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        Transform cam = Camera.main.gameObject.transform;
        if (Input.GetMouseButton(0) || Input.GetAxisRaw("Fire1") == -1)
        {
            Debug.Log("ScaleUp");
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(cam.position, cam.forward, out hit, 100))
            {
                Debug.DrawLine(ray.origin, hit.point,Color.green);
                if (hit.collider.tag == "Scalable")
                {
                    hit.collider.gameObject.GetComponent<ScaleObject>().IncreaseObjectSize();
                }
                
            }
        }
        if (Input.GetMouseButton(1) || Input.GetAxisRaw("Fire1") == 1)
        {
            Debug.Log("ScaleDown");
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(cam.position, cam.forward, out hit, 100))
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
