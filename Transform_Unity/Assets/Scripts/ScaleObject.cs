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
    Material OriginalMaterial;

	public Orientation ObjectOrientation;
	[SerializeField] float MaxSize;
	[SerializeField] float MinSize;
	[SerializeField] float ScaleRate;
	

    [SerializeField] bool CanBeIncreased = true;
    [SerializeField] bool CanBeDecreased = true;
    [SerializeField] bool PlayerColliding = false;
    [SerializeField] Material PlayerCollidingOn;

	// Use this for initialization
	void Start () {

		ParentObject = transform.parent.gameObject;
        OriginalMaterial = GetComponent<Renderer>().material;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void DecreaseObjectSize()
    {
        if (!PlayerColliding)
        {
            CheckMaxSize();
            if (CanBeDecreased)
            {
                
                if (ObjectOrientation == Orientation.x)
                {
                    if (ParentObject.transform.localScale.x >= MinSize)
                    {
                        ScaleX("Shrink");
                    }
                    else
                    {
                        ParentObject.transform.localScale = new Vector3(MinSize, ParentObject.transform.localScale.y, ParentObject.transform.localScale.z);
                        CanBeDecreased = false;
                    }
                }
                if (ObjectOrientation == Orientation.y)
                {
                    if (ParentObject.transform.localScale.y >= MinSize)
                    {
                        ScaleY("Shrink");
                    }
                    else
                    {
                        ParentObject.transform.localScale = new Vector3(ParentObject.transform.localScale.x, MinSize, ParentObject.transform.localScale.z);
                        CanBeDecreased = false;
                    }
                }                
                if (ObjectOrientation == Orientation.z)
                {
                        
                    if (ParentObject.transform.localScale.z >= MinSize)
                    {
                            
                        ScaleZ("Shrink");
                    }
                    else
                    {
                        ParentObject.transform.localScale = new Vector3(ParentObject.transform.localScale.x, ParentObject.transform.localScale.y, MinSize);
                        CanBeDecreased = false;
                    }
                }

            }
        }
    }

    #region Enlarge

    public void IncreaseObjectSize()
	{
        if (!PlayerColliding)
        {
            CheckMinSize();
            if (CanBeIncreased)
            {
                if (ObjectOrientation == Orientation.x)
                {
                    if (ParentObject.transform.localScale.x <= MaxSize)
                    {
                        if (ParentObject.transform.localScale.x <= MaxSize)
                        {
                            ScaleX("Enlarge");
                        }
                        else
                        {
                            ParentObject.transform.localScale = new Vector3(MaxSize, ParentObject.transform.localScale.y, ParentObject.transform.localScale.z);
                            CanBeIncreased = false;
                        }
                    }
                }
                if (ObjectOrientation == Orientation.y)
                {
                    if (ParentObject.transform.localScale.y <= MaxSize)
                    {
                        ScaleY("Enlarge");
                    }
                    else
                    {
                        ParentObject.transform.localScale = new Vector3(ParentObject.transform.localScale.x, MaxSize, ParentObject.transform.localScale.z);
                        CanBeIncreased = false;
                    }
                }
                if (ObjectOrientation == Orientation.z)
                {
                    if (ParentObject.transform.localScale.z <= MaxSize)
                    {
                        ScaleZ("Enlarge");
                    }
                    else
                    {
                        ParentObject.transform.localScale = new Vector3(ParentObject.transform.localScale.x, ParentObject.transform.localScale.y, MaxSize);
                        CanBeIncreased = false;
                    }
                }
               
            }		
        }
       
	}

    #endregion

    void CheckMaxSize()
    {
        switch (ObjectOrientation)
        {
            case Orientation.x:
                if (ParentObject.transform.localScale.x < MaxSize)
                {
                    CanBeIncreased = true;
                }
            break;

            case Orientation.y:
            if (ParentObject.transform.localScale.y < MaxSize)
            {
                CanBeIncreased = true;
            }
            break;

            case Orientation.z:
            if (ParentObject.transform.localScale.z < MaxSize)
            {
                CanBeIncreased = true;
            }
            break;
        }
    }

    void CheckMinSize()
    {
        switch (ObjectOrientation)
        {
            case Orientation.x:
                if (ParentObject.transform.localScale.x > MinSize)
                {
                    CanBeDecreased = true;
                }
                break;

            case Orientation.y:
                if (ParentObject.transform.localScale.y > MinSize)
                {
                    CanBeDecreased = true;
                }
                break;

            case Orientation.z:
                if (ParentObject.transform.localScale.z > MinSize)
                {
                    CanBeDecreased = true;
                }
                break;
        }
    }

    void ScaleX(string ScaleMode)
    {
        if (ScaleMode == "Enlarge")
        {
            ParentObject.transform.localScale = new Vector3(ParentObject.transform.localScale.x + ScaleRate, ParentObject.transform.localScale.y, ParentObject.transform.localScale.z);
        }
        if (ScaleMode == "Shrink")
        {
            ParentObject.transform.localScale = new Vector3(ParentObject.transform.localScale.x - ScaleRate, ParentObject.transform.localScale.y, ParentObject.transform.localScale.z);
        }
        
    }

    void ScaleY(string ScaleMode)
    {
        if (ScaleMode == "Enlarge")
        {
            ParentObject.transform.localScale = new Vector3(ParentObject.transform.localScale.x, ParentObject.transform.localScale.y + ScaleRate, ParentObject.transform.localScale.z);
        }
        if (ScaleMode == "Shrink")
        {
            ParentObject.transform.localScale = new Vector3(ParentObject.transform.localScale.x, ParentObject.transform.localScale.y - ScaleRate, ParentObject.transform.localScale.z);
        }
       
    }

	void ScaleZ(string ScaleMode)
	{
        if (ScaleMode == "Enlarge")
        {
            ParentObject.transform.localScale = new Vector3(ParentObject.transform.localScale.x, ParentObject.transform.localScale.y, ParentObject.transform.localScale.z + ScaleRate);
        }
        if (ScaleMode == "Shrink")
        {
            ParentObject.transform.localScale = new Vector3(ParentObject.transform.localScale.x, ParentObject.transform.localScale.y, ParentObject.transform.localScale.z - ScaleRate);
        }
		
	}

    void OnCollisionEnter()
    {
        PlayerColliding = true;
        GetComponent<Renderer>().material = PlayerCollidingOn;
    }

    void OnCollisionExit()
    {
        PlayerColliding = false;
        GetComponent<Renderer>().material = OriginalMaterial;
    }
}
