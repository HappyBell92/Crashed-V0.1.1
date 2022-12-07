using UnityEngine;
using UnityEngine.Rendering.HighDefinition;
using System.Collections;

public class FogFader : MonoBehaviour
{
	public float fadespeed;
	public LocalVolumetricFog monoFog;
	public float fogStartDistance = 10f;
	public float fogCurrentDistance;
	float fogTargetDistance;

	private void Start()
	{
		fogCurrentDistance = fogStartDistance;
		fogTargetDistance = fogStartDistance;
	}
	//On trigger set MonolithCoverFog Fog Distance to 3000
	private void OnTriggerEnter(Collider other)
	{
		if (other.transform.CompareTag("Player"))
		{
			fogTargetDistance = 3000f;
			Debug.Log($"Fog Triggered");
		}
	}
	private void Update()
	{
		fogCurrentDistance = Mathf.MoveTowards(fogCurrentDistance, fogTargetDistance, fadespeed * Time.deltaTime);
		monoFog.parameters.meanFreePath = fogCurrentDistance;
	}

}
