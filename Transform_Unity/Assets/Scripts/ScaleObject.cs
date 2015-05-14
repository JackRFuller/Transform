using UnityEngine;
using System.Collections;

public class ScaleObject : MonoBehaviour {

	public enum Orientation
	{
		x,
		y,
		z,
	};

	[SerializeField] GameObject ParentObject;

	public Orientation ObjectOrientation;
	[SerializeField] float MaxSize;
	[SerializeField] float MinSize;
	[SerializeField] float ScaleRate;
	[SerializeField] Material ScaledMaterial;

	// Use this for initialization
	void Start () {

		ParentObject = transform.parent.root.gameObject;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void IncreaseObjectSize()
	{
		if (ObjectOrientation == Orientation.x)
		{
			if(ParentObject.transform.localScale.x <= MaxSize)
			{

			}
		}
		if (ObjectOrientation == Orientation.y)
		{
			
		}
		if (ObjectOrientation == Orientation.z)
		{
			if(ParentObject.transform.localScale.z <= MaxSize)
			{
				ScaleZ();
			}
			else
			{
				ParentObject.transform.localScale = new Vector3(ParentObject.transform.localScale.x,ParentObject.transform.localScale.y,MaxSize);
			}
		}
	}

	void ScaleZ()
	{
		ParentObject.transform.localScale = new Vector3(ParentObject.transform.localScale.x,ParentObject.transform.localScale.y,ParentObject.transform.localScale.z + ScaleRate);
	}
}
