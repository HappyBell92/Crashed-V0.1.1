using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orientationcheck : MonoBehaviour
{
    private Vector2 turn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        turn.y += Input.GetAxis("Mouse X");
        transform.localRotation = Quaternion.Euler(0, turn.y, 0 * Time.deltaTime);
    }
}
