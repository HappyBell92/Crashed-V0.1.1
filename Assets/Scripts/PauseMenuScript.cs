using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{
    public GameObject pauseMenu;
    private PlayerRespawn respawnScript;
    private PlayerMovement getPausedBool;
    private Orientationcheck orientationScript;


    // Start is called before the first frame update
    void Start()
    {
        respawnScript = GameObject.Find("Player").GetComponent<PlayerRespawn>();
        getPausedBool = GameObject.Find("Player").GetComponent<PlayerMovement>();
        orientationScript = GameObject.Find("Orientation").GetComponent<Orientationcheck>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResumeButton()
    {
        Time.timeScale = 1;
        Cursor.visible = false;
        getPausedBool.isPaused = false;
        orientationScript.enabled = true;
        pauseMenu.SetActive(false);
    }

    public void CheckpointButton()
    {
        Time.timeScale = 1;
        Cursor.visible = false;
        getPausedBool.isPaused = false;
        orientationScript.enabled = true;
        pauseMenu.SetActive(false);
        respawnScript.RespawnButton();
    }

    public void RestartButton()
    {
        Time.timeScale = 1;
        Cursor.visible = true;
        pauseMenu.SetActive(false);
        getPausedBool.isPaused = false;
        orientationScript.enabled = true;
        SceneManager.LoadScene("Gameplay Test");
    }

    public void MainMenuButton()
    {
        Time.timeScale = 1;
        Cursor.visible = true;
        SceneManager.LoadScene("Main Menu");
    }
}
