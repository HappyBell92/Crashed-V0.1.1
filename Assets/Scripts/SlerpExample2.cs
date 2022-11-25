using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlerpExample2 : MonoBehaviour
{
	[Header("Press H, J and K keys to slerp to rotations of transforms listed.")] 
	[SerializeField] Transform transformA;
	[SerializeField] Transform transformB;
	[SerializeField] Transform transformC;
	Quaternion from;
	Quaternion to;
	
	public float timeCount = 0.0f;
	void Start()
	{
		from = transform.rotation; 
		to = transform.rotation; //Quaternions must be initialized first because math operations cannot be done on zero quaternions
	}

	void Update()
	{
		DoTheRotation();

		if (Mathf.Approximately(timeCount, 1f)) //Is rotation finished?
		{
			if(Input.GetKeyDown(KeyCode.H))
			{
				SlerpToA();
			}
			if(Input.GetKeyDown(KeyCode.J))
			{
				SlerpToB();
			}
			if(Input.GetKeyDown(KeyCode.K))
			{
				SlerpToC();
			}
		}

	}

	void SlerpToA()
	{
		Debug.Log($"Slerping to A");
		from = transform.rotation; //New starting rotation is current rotation
		to = transformA.rotation; //Pick new destination
		timeCount = 0f; //Reset counter so it starts again
	}

	void SlerpToB()
	{
		Debug.Log($"Slerping to B");
		from = transform.rotation; //New starting rotation is current rotation
		to = transformB.rotation; //Pick new destination
		timeCount = 0f; //Reset counter so it starts again
	}
	void SlerpToC()
	{
		Debug.Log($"Slerping to C");
		from = transform.rotation; //New starting rotation is current rotation
		to = transformC.rotation; //Pick new destination
		timeCount = 0f; //Reset counter so it starts again
	}
	void DoTheRotation()
	{
			transform.rotation = Quaternion.Lerp(from, to, timeCount); //Do the slerp
			timeCount = Mathf.MoveTowards(timeCount, 1f, Time.deltaTime); //Run time counter towards so it reaches 1f in 1 second
	}
}
