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
    [SerializeField] bool useRootParent = true;
	[SerializeField] float MaxSize;
	[SerializeField] float MinSize;
	[SerializeField] float ScaleRate;
	

    [SerializeField] bool CanBeIncreased = true;
    [SerializeField] bool CanBeDecreased = true;
    [SerializeField] bool PlayerColliding = false;
    [SerializeField] bool RevertToOriginal;
    private Vector3 originalScale;
    [SerializeField] float ReversionWaitTime;
    [SerializeField] float TimeToRevert;
    [SerializeField] Material PlayerCollidingOn;

    private float currRevertTime;
    private bool startCountdownToRevert;
    private bool startReverting;
    Vector3 scaleFrom;

	// Use this for initialization
	void Start () {
        
        if(!useRootParent)
        {
            ParentObject = transform.parent.gameObject;
        }
        else
        {
          ParentObject = transform.parent.root.gameObject;  
        }


		//ParentObject = useRootParent ?  transform.parent.root.gameObject : transform.parent.gameObject;
        OriginalMaterial = GetComponent<Renderer>().material;
        originalScale = transform.parent.transform.localScale;
	}
	
	// Update is called once per frame
	void Update ()
    {
        RevertScale();

        if (GetComponent<Rigidbody>() == null)
            return;

        Debug.Log(GetComponent<Rigidbody>().velocity);
	}

    private void RevertScale()
    {
        if (!RevertToOriginal)
            return;

        if (transform.parent.transform.localScale != originalScale && !startCountdownToRevert)
        {
             StartCoroutine(waitToRevert(ReversionWaitTime));
        }

        if (startReverting)
        {
            currRevertTime += Time.deltaTime;
            float perc = currRevertTime / TimeToRevert;
            transform.parent.transform.localScale = Vector3.Lerp(scaleFrom, originalScale, perc);

            float magScaleDiff = Mathf.Abs((transform.parent.transform.localScale - originalScale).magnitude);
            
            if (magScaleDiff <= 0.01f)
            {
                currRevertTime = 0;
                startCountdownToRevert = false;
                startReverting = false;
                transform.parent.transform.localScale = originalScale;
            }
        }
    }

    private IEnumerator waitToRevert(float _time)
    {
        startCountdownToRevert = true;
        yield return new WaitForSeconds(_time);
        Debug.Log("WE CAN REVERT NOW");
        startReverting = true;
        scaleFrom = transform.parent.transform.localScale;
        
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
        currRevertTime = 0;
        startCountdownToRevert = false;
        startReverting = false;
        scaleFrom = transform.parent.transform.localScale;
        StopAllCoroutines();
     
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
        currRevertTime = 0;
        startCountdownToRevert = false;
        startReverting = false;
        scaleFrom = transform.parent.transform.localScale;
        StopAllCoroutines();

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
        currRevertTime = 0;
        startCountdownToRevert = false;
        startReverting = false;
        scaleFrom = transform.parent.transform.localScale;
        StopAllCoroutines();

        if (ScaleMode == "Enlarge")
        {
            ParentObject.transform.localScale = new Vector3(ParentObject.transform.localScale.x, ParentObject.transform.localScale.y, ParentObject.transform.localScale.z + ScaleRate);
        }
        if (ScaleMode == "Shrink")
        {
            ParentObject.transform.localScale = new Vector3(ParentObject.transform.localScale.x, ParentObject.transform.localScale.y, ParentObject.transform.localScale.z - ScaleRate);
        }
		
	}

    void OnCollisionEnter(Collision other)
    {
       
       GetComponent<Renderer>().material = PlayerCollidingOn;   

    }

    void OnCollisionExit(Collision other)
    {
       
       GetComponent<Renderer>().material = OriginalMaterial;

    
    }

    void OnTriggerStay(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            other.transform.parent = gameObject.transform;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Player")
            other.transform.parent = null;
    }
}
