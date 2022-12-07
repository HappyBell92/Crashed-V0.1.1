using UnityEngine;
using UnityEngine.Rendering.HighDefinition;
using System.Collections;

public class FogFader : MonoBehaviour
{
    public float fadespeed;
    public LocalVolumetricFog monoFog;
    public float fogStartDistance = 10f;
    public float fogTargetDistance = 3000f;
    float fogCurrentDistance = 10f;

    private void Start()
    {
        fogCurrentDistance = fogStartDistance;
    }
    //On trigger set MonolithCoverFog Fog Distance to 3000
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            fogCurrentDistance = Mathf.MoveTowards(fogCurrentDistance, fogTargetDistance, fadespeed * Time.deltaTime);
            monoFog.parameters.meanFreePath = fogTargetDistance;
        }
    }
    private void Update()
    {
 
    }

}
