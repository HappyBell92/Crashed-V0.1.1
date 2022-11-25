using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlerpExample : MonoBehaviour
{
	[SerializeField] Transform from;
	[SerializeField] Transform to;
	[SerializeField] float speed;
	//[SerializeField] float targetTime;
	
	public float timeCount = 0.0f; //public to visualize it in inspector

	void Update()
	{
		transform.rotation = Quaternion.Lerp(from.rotation, to.rotation, timeCount * speed);
		timeCount = timeCount + Time.deltaTime;
		timeCount = Mathf.Repeat(timeCount, 1f); //Make the counter repeat for visualization purposes

	}
}
