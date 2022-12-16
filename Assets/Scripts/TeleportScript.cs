using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class TeleportScript : MonoBehaviour
{
    public Transform destination;
    public Transform triggerpos;
    public Vector3 gravityScale;
    public float targetRotationZ;
    public float targetRotationX;
    public float targetRotationY;
    //public float orientation;

    //public GameObject orientationObject;
    //public Orientationcheck orientationScript;

    // Start is called before the first frame update
    void Start()
    {
        //orientationObject = GameObject.Find("Orientation");
        //orientationScript = GameObject.Find("Orientation").GetComponent<Orientationcheck>();
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

    //IEnumerator RotateOrientation()
    //{
    //    orientationScript.enabled = false;
    //    yield return new WaitForSeconds(0.01f);
    //    orientationObject.transform.rotation = quaternion.Euler(0, orientation, 0);
    //    yield return new WaitForSeconds(0.01f);
    //    orientationScript.enabled = true;
    //}
}
