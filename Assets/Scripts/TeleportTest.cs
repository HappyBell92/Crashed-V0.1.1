using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            gameObject.transform.position = new Vector3(0f, 7f, 10.31f);
        }
    }

    //IEnumerator Teleport()
    //{

    //}
}
