using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{

    public Vector3 respawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void RespawnNow()
    {
        transform.position = respawnPoint;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Death")
        {
            RespawnNow();
        }
    }
}
