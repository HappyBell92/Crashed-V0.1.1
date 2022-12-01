using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScatterGate : MonoBehaviour
{
    SkinnedMeshRenderer meshRenderer;
    bool start;
    float blend;
    public float blendSpeed;
    private void Start()
    {
        meshRenderer = this.GetComponent<SkinnedMeshRenderer>();
    }
    //Trigger
    private void OnTriggerEnter(Collider other)
    {

        if (other.transform.tag == "Player")
        {
            start = true;
        }
    }
    private void Update()
    {

        if (!start)
        {
            if (blend >= 0f)
            {
                meshRenderer.SetBlendShapeWeight(0, blend);
                blend -= blendSpeed;
            }

        }
        if (start)
        {
            if (blend <= 100f)
            {
                meshRenderer.SetBlendShapeWeight(0, blend);
                blend += blendSpeed;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            start = false;
        }

    }
}