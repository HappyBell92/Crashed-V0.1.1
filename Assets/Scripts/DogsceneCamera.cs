using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogsceneCamera : MonoBehaviour
{
	[SerializeField] Camera playerCamera;
	[SerializeField] GameObject Dogo;
	float timer = 0f;
	float smoothTime;
	void Start()
	{
		transform.rotation = playerCamera.transform.rotation;
		playerCamera.gameObject.SetActive(false);	
		transform.parent = null;
	}

	void Update()
	{
		// -(cos(PI * x) - 1) / 2
		//smoothTime = 

		Quaternion lookAtDog = Quaternion.LookRotation(Dogo.transform.position - transform.position, Vector3.up);
		Debug.DrawRay(transform.position, Dogo.transform.position - transform.position, Color.red, Time.deltaTime);
		transform.rotation = Quaternion.Slerp(transform.rotation, lookAtDog, timer);
		if(timer < 1f)
		{
			timer += Time.deltaTime;
		}
		
	}
}
