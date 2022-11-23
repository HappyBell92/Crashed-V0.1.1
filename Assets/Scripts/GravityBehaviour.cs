using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityBehaviour : MonoBehaviour
{
    public GameObject player;

    void Start()
    {

    }

    public void GravityDown()
    {
        Debug.Log("Gravity Down!");
        Physics.gravity = new Vector3(0, -9.81f, 0);
        player.transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    public void GravityUp()
    {
        Debug.Log("Gravity Up!");
        Physics.gravity = new Vector3(0, 9.81f, 0);
        player.transform.rotation = Quaternion.Euler(180, 0, 0);
    }

    public void GravityNorth()
    {
        Debug.Log("Gravity North!");
        Physics.gravity = new Vector3(0, 0, 9.81f);
        player.transform.rotation = Quaternion.Euler(-90, 0, 0);
    }

    public void GravityEast()
    {
        Debug.Log("Gravity East!");
        Physics.gravity = new Vector3(9.81f, 0, 0);
        player.transform.rotation = Quaternion.Euler(0, 0, 90);
    }

    public void GravitySouth()
    {
        Debug.Log("Gravity South!");
        Physics.gravity = new Vector3(0, 0, -9.81f);
        player.transform.rotation = Quaternion.Euler(90, 0, 0);
    }

    public void GravityWest()
    {
        Debug.Log("Gravity West!");
        Physics.gravity = new Vector3(-9.81f, 0, 0);
        player.transform.rotation = Quaternion.Euler(0, 0, -90);
    }
}
