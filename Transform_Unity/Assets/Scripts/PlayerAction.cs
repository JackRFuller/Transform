using UnityEngine;
using System.Collections;

public class PlayerAction : MonoBehaviour {

    public GameObject StaffBall;
    private Material OriginalMaterial;

    public Material ShrinkingMaterial;
    public Material EnlargingMaterial;
    

	// Use this for initialization
	void Start () {

        OriginalMaterial = StaffBall.GetComponent<Renderer>().material;
	
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButton(0))
        {
            StaffBall.GetComponent<Renderer>().material = EnlargingMaterial;
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
            StaffBall.GetComponent<Renderer>().material = ShrinkingMaterial;
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

        if (Input.GetMouseButtonUp(0) || Input.GetMouseButtonUp(1))
        {
            StaffBall.GetComponent<Renderer>().material = OriginalMaterial;
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
