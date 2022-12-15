using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InteriorSceneSwitch : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter(collider other)

    {
        if (other.transform.tag == "Player")
        {
            SceneManagemer.LoadScene (sceneName :"")
            DebugLog.("yee");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
