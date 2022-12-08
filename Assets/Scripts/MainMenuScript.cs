using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayBUtton()
    {
        SceneManager.LoadScene("Main Monolith Scene");
    }

    public void ExitGameButton()
    {
        Application.Quit();
        Debug.Log("Quitting Game!");
    }
}
