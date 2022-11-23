using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orientationcheck : MonoBehaviour
{
    public Vector2 turn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, -transform.up, Color.red, Time.deltaTime);

        turn.y += Input.GetAxis("Mouse X");
        transform.localRotation = Quaternion.Euler(0, turn.y, 0);
    }
}
