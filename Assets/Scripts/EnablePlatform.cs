using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnablePlatform : MonoBehaviour
{
    public MovingPlatformScript platform;
    public PlayerMovement player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Beep");
            player.walkSpeed = 0;
            player.sprintSpeed = 0;
            platform.enabled = true;
        }
    }
}
