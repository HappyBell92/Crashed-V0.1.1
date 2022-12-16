using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuOtherScript : MonoBehaviour
{
    public bool mouseOn;
    public PhysicalPlayButton playButton;
    public GameObject ship;
    Animator playGrow;
    Animator quitGrow;
    Animator shipCrash;
    Animator fire;
    Animator quitFire;
    public Animator soundFade;
    // Start is called before the first frame update
    void Start()
    {
        mouseOn = false;
        playGrow = GameObject.Find("PlayButton").GetComponent<Animator>();
        quitGrow = GameObject.Find("QuitButton").GetComponent<Animator>();
        fire = GameObject.Find("MenuLightOpen").GetComponent<Animator>();
        quitFire = GameObject.Find("MenuLightQuit").GetComponent<Animator>();
        shipCrash = GameObject.Find("ShipObjectForMenu").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = 1;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, 100))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 100, Color.red);
            if(hit.transform.tag == "PlayButton")
            {
                mouseOn = true;
                playGrow.SetBool("mouseOn", true);
                fire.SetBool("mouseOn", true);
                if (Input.GetMouseButtonDown(0))
                {
                    soundFade.SetBool("CutsceneOn", true);
                    playGrow.SetBool("CutsceneOn", true);
                    quitGrow.SetBool("CutsceneOn", true);
                    ship.SetActive(true);
                    Cursor.lockState = CursorLockMode.Locked;
                    Cursor.visible = false;
                }
            }

            if (hit.transform.tag != "PlayButton")
            {
                mouseOn = false;
                playGrow.SetBool("mouseOn", false);
                fire.SetBool("mouseOn", false);
            }

        }

        Debug.Log(hit.transform.name);

        if(hit.transform.tag == "QuitButton")
        {
            mouseOn = true;
            quitGrow.SetBool("mouseOn", true);
            quitFire.SetBool("mouseOn", true);
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("Quitting Game");
                Application.Quit();
            }
        }

        if (hit.transform.tag != "QuitButton")
        {
            mouseOn = false;
            quitGrow.SetBool("mouseOn", false);
            quitFire.SetBool("mouseOn", false);
        }
    }
}
