using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportTest2 : MonoBehaviour
{
    public Transform destination;
    public Transform triggerpos;
    public Vector3 gravityScale;
    public float targetRotationZ;
    public float targetRotationX;
    public float targetRotationY;

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
            other.gameObject.transform.position -= (triggerpos.position - destination.position);
            Physics.gravity = gravityScale;
            other.gameObject.transform.rotation = Quaternion.Euler(targetRotationX, targetRotationY, targetRotationZ);
        }
    }
}
