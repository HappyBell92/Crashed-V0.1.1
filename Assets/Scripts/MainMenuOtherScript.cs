using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuOtherScript : MonoBehaviour
{
    public bool mouseOn;
    public PhysicalPlayButton playButton;
    public GameObject ship;
    Animator playGrow;
    Animator shipCrash;
    // Start is called before the first frame update
    void Start()
    {
        mouseOn = false;
        playGrow = GameObject.Find("PlayPhysicalButton").GetComponent<Animator>();
        shipCrash = GameObject.Find("ShipObjectForMenu").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, 100))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 100, Color.red);
            if(hit.transform.tag == "PlayButton")
            {
                mouseOn = true;
                playGrow.SetBool("mouseOn", true);
                if (Input.GetMouseButtonDown(0))
                {
                    playButton.PlayGame();
                    ship.SetActive(true);
                    Cursor.lockState = CursorLockMode.Locked;
                    Cursor.visible = false;
                }
            }

            if (hit.transform.tag != "PlayButton")
            {
                mouseOn = false;
                playGrow.SetBool("mouseOn", false);
            }

                if (hit.transform.tag == "QuitButton")
            {
                if (Input.GetMouseButtonDown(0))
                {
                    playButton.QuitGame();
                }
            }
            Debug.Log(hit.transform.name);
        }
    }
}
