using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{

    public Vector3 respawnPoint;
    AudioSource death;

    // Start is called before the first frame update
    void Start()
    {
        death= GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void RespawnNow()
    {
        transform.position = respawnPoint;
        death.Play();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Death")
        {
            RespawnNow();
        }
    }
}
