using UnityEngine;
using System.Collections;

public class PlayerAction : MonoBehaviour {

	[SerializeField] float RaycastRange;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetMouseButtonUp(0))
		{
			ScaleObject();
		}

		if(Input.GetMouseButton(1))
		{
			ShrinkObject();
		}
	
	}

	void ScaleObject()
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast(ray, out hit, 100))
		{
			Debug.Log(hit.collider.name);
			if(hit.collider.tag == "Scalable")
			{
				hit.collider.gameObject.GetComponent<ScaleObject>().IncreaseObjectSize();
				Debug.Log("Hit");
			}
		}
			
	}

	void ShrinkObject()
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast(ray, out hit, RaycastRange))
		{
			if(hit.collider.tag == "Player")
			{
				Debug.Log("Success1");
			}
		}
	}
}
