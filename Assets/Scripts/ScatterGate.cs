using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScatterGate : MonoBehaviour
{
    SkinnedMeshRenderer meshRenderer;
    bool start;
    public float blend;
    public float blendSpeed = 0.3f;
    AudioSource shatter;
    private void Start()
    {
        meshRenderer = this.GetComponent<SkinnedMeshRenderer>();
        shatter = GetComponent<AudioSource>();
    }
    //Trigger
    private void OnTriggerEnter(Collider other)
    {

        if (other.transform.tag == "Player")
        {
            start = true;
            shatter.pitch = 1;
            shatter.time = shatter.clip.length + 0;
            shatter.Play();
        }
    }

    private void Update()
    {
        if (start)
        {
            if (blend <= 100)
            {
                blend += blendSpeed;
                meshRenderer.SetBlendShapeWeight(0, Mathf.Clamp(blend, 0f, 100f));
            }
        }
        if (!start)
        {
            if (blend >= 0)
            {
                blend -= blendSpeed;
                meshRenderer.SetBlendShapeWeight(0, Mathf.Clamp(blend, 0, 100));
            }

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            start = false;
            shatter.pitch = -1;
            shatter.time = shatter.clip.length - 0.01f;
            shatter.Play();
        }

    }
}