using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraX : MonoBehaviour
{
    private Vector2 turn;
    public float turnSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        turn.x += Input.GetAxis("Mouse Y");
        transform.localRotation = Quaternion.Euler(Mathf.Clamp(-turn.x, -90, 90), 0, 0 * Time.deltaTime);
    }
}
