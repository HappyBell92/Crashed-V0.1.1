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
    private void OnTriggerEnter(Collider other)

    {
        if (other.transform.tag == "Player")
        {
            SceneManager.LoadScene(sceneName: "Interior Levels");
            Debug.Log("yee");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
