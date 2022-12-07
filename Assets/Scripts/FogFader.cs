using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;
using System.Collections;

public class FogFader : MonoBehaviour
{
    public VolumeProfile cheems;
    public bool enableFog;
    public bool overrideFog;
    public bool start;
    public float fadespeed;
    //sets fog attenuation distance to 3 on Run
    private void Start()
    {
        if (cheems.TryGet<Fog>(out var fog))
        {
            fog.meanFreePath.value = 3;
        }
    }
    //collider trigger
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            start = true;
        }
    }
    //set fog to 150 if below
    private void Update()
    {
        if (cheems.TryGet<Fog>(out var fog))
            if (start)
            {
                {
                    if (fog.meanFreePath.value <= 150)
                    {           //lul
                        fog.meanFreePath.value = 150;
                    }
                }
            }

    }
    IEnumerator Fadefog()
    {
        float fadeTime = 0f;
        while (fadeTime < 1f)
        {
            Mathf.Clamp(fadeTime, 0f, 1f);
            fadeTime += -Time.deltaTime * fadespeed;
        }
        yield return null;
    }
}
