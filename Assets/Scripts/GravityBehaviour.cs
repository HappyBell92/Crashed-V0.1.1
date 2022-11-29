using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityBehaviour : MonoBehaviour
{
    public GameObject player;

    //public float rotationSpeed = 10f;

    public Transform from;
    public Transform up;
    public Transform down;
    public Transform north;
    public Transform south;
    public Transform east;
    public Transform west;

    public float speed = 0.25f;
    public float timePassedWait = 1f;
    float timeCount = 0.0f;

    void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.G))
        {
            GravityNorth();
        }
    }

    public void GravityDown()
    {
        Debug.Log("Gravity Down!");
        Physics.gravity = new Vector3(0, -9.81f, 0);
        StartCoroutine(RotateDown());
    }

    IEnumerator RotateDown()
    {
        float timepassed = 0;
        while (timepassed < 1.5)
        {
            timepassed += Time.deltaTime;

            player.transform.rotation = Quaternion.Lerp(from.rotation, down.rotation, timeCount * speed);
            timeCount = timeCount + Time.deltaTime;

            if (timepassed >= timePassedWait)
            {
                from = down;
            }

            yield return null;


        }
    }

    public void GravityUp()
    {
        Debug.Log("Gravity Up!");
        Physics.gravity = new Vector3(0, 9.81f, 0);
        StartCoroutine(RotateUp());
    }

    IEnumerator RotateUp()
    {

        float timepassed = 0;
        while (timepassed < 1.5)
        {
            timepassed += Time.deltaTime;

            player.transform.rotation = Quaternion.Lerp(from.rotation, up.rotation, timeCount * speed);
            timeCount = timeCount + Time.deltaTime;

            if (timepassed >= timePassedWait)
            {
                from = up;
            }

            yield return null;

            
        }

        

    }

    public void GravityNorth()
    {
        Debug.Log("Gravity North!");
        Physics.gravity = new Vector3(0, 0, 9.81f);
        StartCoroutine(RotateNorth());
    }

    IEnumerator RotateNorth()
    {
        float timepassed = 0;
        while (timepassed < 1.5)
        {
            timepassed += Time.deltaTime;

            player.transform.rotation = Quaternion.Lerp(from.rotation, north.rotation, timeCount * speed);
            timeCount = timeCount + Time.deltaTime;

            if (timepassed >= timePassedWait)
            {
                from = north;
            }

            yield return null;


        }
    }

    public void GravityEast()
    {
        Debug.Log("Gravity East!");
        Physics.gravity = new Vector3(9.81f, 0, 0);
        StartCoroutine(RotateEast());
    }

    IEnumerator RotateEast()
    {
        float timepassed = 0;
        while (timepassed < 1.5)
        {
            timepassed += Time.deltaTime;

            player.transform.rotation = Quaternion.Lerp(from.rotation, east.rotation, timeCount * speed);
            timeCount = timeCount + Time.deltaTime;

            if (timepassed >= timePassedWait)
            {
                from = east;
            }

            yield return null;


        }
    }

    public void GravitySouth()
    {
        Debug.Log("Gravity South!");
        Physics.gravity = new Vector3(0, 0, -9.81f);
        StartCoroutine(RotateSouth());
    }

    IEnumerator RotateSouth()
    {
        float timepassed = 0;
        while (timepassed < 1.5)
        {
            timepassed += Time.deltaTime;

            player.transform.rotation = Quaternion.Lerp(from.rotation, south.rotation, timeCount * speed);
            timeCount = timeCount + Time.deltaTime;

            if (timepassed >= timePassedWait)
            {
                from = south;
            }

            yield return null;


        }
    }

    public void GravityWest()
    {
        Debug.Log("Gravity West!");
        Physics.gravity = new Vector3(-9.81f, 0, 0);
        StartCoroutine(RotateWest());
    }

    IEnumerator RotateWest()
    {
        float timepassed = 0;
        while (timepassed < 1.5)
        {
            timepassed += Time.deltaTime;

            player.transform.rotation = Quaternion.Slerp(from.rotation, west.rotation, timeCount * speed);
            timeCount = timeCount + Time.deltaTime;

            if (timepassed >= timePassedWait)
            {
                from = west;
            }

            yield return null;


        }
    }
}
