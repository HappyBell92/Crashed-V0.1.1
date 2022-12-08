using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{

    public GameObject blackOutImage;
    public GameObject crashedText;
    public TextFadeScript textFade;
    public float fadeSpeed = 1f;
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
        //SceneManager.LoadScene("Main Monolith Scene");
        StartCoroutine(FadeoutBlackImage());
        blackOutImage.SetActive(true);
        Debug.Log("beep");
        StartCoroutine(ChangeToMonolith());
        
    }

    public void ExitGameButton()
    {
        Application.Quit();
        Debug.Log("Quitting Game!");
    }

    public IEnumerator FadeoutBlackImage(bool fadeToBlack = true)
    {
        Color objectColor = blackOutImage.GetComponent<Image>().color;
        float fadeAmount;

        if (fadeToBlack)
        {
            while (blackOutImage.GetComponent<Image>().color.a < 1)
            {
                fadeAmount = objectColor.a + (fadeSpeed * Time.deltaTime);

                objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
                blackOutImage.GetComponent<Image>().color = objectColor;
                yield return null;
            }
        }
    }

    IEnumerator ChangeToMonolith()
    {
        Debug.Log("Couritne Started");
        yield return new WaitForSeconds(3);
        crashedText.SetActive(true);
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("Main Monolith Scene");
    }
}
