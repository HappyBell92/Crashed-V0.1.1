using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointScript : MonoBehaviour
{
    private PlayerRespawn playerRespawn;

    // Start is called before the first frame update
    void Start()
    {
        playerRespawn= GameObject.Find("Player").GetComponent<PlayerRespawn>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Player")
        {
            playerRespawn.respawnPoint = transform.position;
        }
    }
}
