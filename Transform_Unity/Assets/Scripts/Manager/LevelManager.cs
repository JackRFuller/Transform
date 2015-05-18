using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

    [SerializeField] GameObject PC;
    public Vector3 StartingPos;

	// Use this for initialization
	void Start () {

        PC = GameObject.FindGameObjectWithTag("Player");
        StartingPos = PC.transform.position;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Restart()
    {
        PC.transform.position = StartingPos;
    }
}
