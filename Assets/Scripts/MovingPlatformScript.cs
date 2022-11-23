using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformScript : MonoBehaviour
{
    [SerializeField] private List<Transform> waypoints;
    [SerializeField] private float moveSpeed = 5f;
    public int _currentWaypoint;
    public bool rotateAround = false;

    // Start is called before the first frame update
    private void Start()
    {
        if (waypoints.Count <= 0) return;
        _currentWaypoint = 0;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if(rotateAround == false)
        {
            HandleMovement();
        }
        
        else if (rotateAround == true)
        {
            HandleMovementRotate();
        }
    }

    private void HandleMovement()
    {

        transform.position = Vector3.MoveTowards(transform.position, waypoints[_currentWaypoint].transform.position,
            (moveSpeed * Time.deltaTime));

        if (Vector3.Distance(waypoints[_currentWaypoint].transform.position, transform.position) <= 0)
        {
            _currentWaypoint++;
        }

        if (_currentWaypoint != waypoints.Count) return;
        {
            waypoints.Reverse();
            _currentWaypoint = 0;
        }
    }

    private void HandleMovementRotate()
    {
        transform.position = Vector3.MoveTowards(transform.position, waypoints[_currentWaypoint].transform.position,
            (moveSpeed * Time.deltaTime));

        if (Vector3.Distance(waypoints[_currentWaypoint].transform.position, transform.position) <= 0)
        {
            _currentWaypoint++;
        }

        if (_currentWaypoint != waypoints.Count) return;
        {
            _currentWaypoint = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (!other.CompareTag("Player")) return;
        Debug.Log("Parented");
        other.transform.parent = transform;
    }

    private void OnTriggerExit(Collider other)
    {
        
        if (!other.CompareTag("Player")) return;
        Debug.Log("Unparented");
        other.transform.parent = null;
    }
}
