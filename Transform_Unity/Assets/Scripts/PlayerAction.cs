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
        ControllerDetection();

        if (rtCanShoot)
        {
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
        if (ltCanShoot)
        {
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

    private void ControllerDetection()
    {
        if (RigidbodyFirstPersonController.ControllerInUse)
        {
            rtCanShoot = Input.GetAxisRaw("Fire1") == -1 ? true : false;
            ltCanShoot = Input.GetAxisRaw("Fire1") == 1 ? true : false;
        }
        else
        {
            rtCanShoot = Input.GetMouseButton(0) ? true : false;
            ltCanShoot = Input.GetMouseButton(1) ? true : false;
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
