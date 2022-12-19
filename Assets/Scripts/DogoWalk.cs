using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DogoWalk : MonoBehaviour
{
	//[SerializeField] DogosceneTrigger dogoscene;
	[SerializeField] GameObject playerCamera;
	[SerializeField] Transform goal;
	[SerializeField] Collider walkableCollider;
	[SerializeField] Animator dogAnimation;
	NavMeshAgent dogAgent; // B)
	Quaternion startRotation;
	Quaternion endRotation;
	Vector3 lookAtPosition;
	bool dogFound = false;
	//bool moving = true;
	float turnTimer = 0f;
	float navigationTimer = 0f;
	[SerializeField] float timerMultiplier = .33f;
	float smoothTime;
	void Start()
	{
		dogAgent = GetComponent<NavMeshAgent>();
	}

	// Update is called once per frame
	void Update()
	{
		if(dogFound)
		{
			smoothTime = (-(Mathf.Cos(Mathf.PI * turnTimer) - 1) / 2);

			
			Debug.DrawRay(transform.position, lookAtPosition - transform.position , Color.blue, Time.deltaTime);
			transform.rotation = Quaternion.Slerp(startRotation, endRotation, smoothTime);
			//Debug.Log($"slerping with smoothTime value {smoothTime}");
			if(turnTimer < 1f)
			{
				turnTimer += Time.deltaTime * timerMultiplier;
			}
		}
		else
		{
			Navigate();
		}
	}

	void Navigate()
	{
		if(dogAgent.remainingDistance < 0.1)
		{
			dogAnimation.SetBool("Walking", false);
			//Debug.Log($"Dog waiting");
			if(navigationTimer < 2f)
			{
				navigationTimer += Time.deltaTime;
			}
			else
			{
				navigationTimer = 0f;
				goal.position = RandomPointInBounds(walkableCollider.bounds);
				dogAgent.destination = goal.position;
			}	
		}
		else
		{
			dogAnimation.SetBool("Walking", true);
		}
	}

	public void DogFound()
	{
		startRotation = transform.rotation;
		lookAtPosition = new Vector3(playerCamera.transform.position.x, transform.position.y, playerCamera.transform.position.z);
		endRotation = Quaternion.LookRotation(lookAtPosition - transform.position, Vector3.up);
		//endRotation = Quaternion.LookRotation(playerCamera.transform.position - transform.position, Vector3.up);
		//Debug.Log($"lookatposition = {lookAtPosition}");
		dogAgent.isStopped = true;
		dogAgent.enabled = false; //Disable agent just in case
		dogFound = true;
		dogAnimation.SetBool("Walking", false);
		dogAnimation.SetTrigger("GetPet");
		//dogoscene.DogGotPet();
	}

	Vector3 RandomPointInBounds(Bounds bounds) 
	{
		return new Vector3(
			Random.Range(bounds.min.x, bounds.max.x),
			Random.Range(bounds.min.y, bounds.max.y),
			Random.Range(bounds.min.z, bounds.max.z)
			);
    }

}
