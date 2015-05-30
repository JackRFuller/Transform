using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Reset))]
public class MovingPlatform : MonoBehaviour
{

    public Transform[] waypoints;
    public bool moveConstantly;
    public float speed;
    public bool loop;
    private Vector3 moveDirection;
    private int curWaypoint;
    private Rigidbody platformRigidbody;
    private bool moveToTarget;
    // Use this for initialization
    void Start()
    {
        platformRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        if (moveConstantly)
            MoveViaWaypoints();
        else
            MoveInIncrements();
    }

    private void MoveViaWaypoints()
    {
        if (curWaypoint < waypoints.Length)
        {
            Vector3 _curWaypointPos = waypoints[curWaypoint].position;
            moveDirection = _curWaypointPos - transform.position;

            if (moveDirection.magnitude < 0.1f)
            {
                transform.position = _curWaypointPos;
                curWaypoint++;
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, _curWaypointPos, Time.deltaTime * speed);
            }
        }
        else
        {
            if (loop)
            {
                curWaypoint = 0;
            }
        }
    }

    private void MoveInIncrements()
    {
        if (curWaypoint < waypoints.Length)
        {
            if (moveToTarget)
            {
                Vector3 _curWaypointPos = waypoints[curWaypoint].position;
                moveDirection = _curWaypointPos - transform.position;
                transform.position = Vector3.MoveTowards(transform.position, _curWaypointPos, Time.deltaTime * speed);

                if (moveDirection.magnitude < 0.1f)
                {
                    transform.position = _curWaypointPos;
                    moveToTarget = false;
                    curWaypoint++;
                }
            }
        }
        else
        {
            if (loop)
                curWaypoint = 0;
        }
    }


    private void Reset()
    {
        curWaypoint = 0;
    }

    private void StartTrigger()
    {
        moveToTarget = true;
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
            other.transform.parent = gameObject.transform;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
            other.transform.parent = null;
    }
}
