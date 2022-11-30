using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportTest2 : MonoBehaviour
{
    public Transform destination;
    public Transform triggerpos;

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
        if (other.gameObject.tag == ("Player"))
        {
            Debug.Log("Teleport");
            //Vector3 relPos = triggerpos.position - other.gameObject.transform.position;
            //other.gameObject.transform.position = destination.position + relPos;
            other.gameObject.transform.position -= (triggerpos.position - destination.position);

        }
    }
}
