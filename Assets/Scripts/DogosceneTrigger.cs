using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DogosceneTrigger : MonoBehaviour
{
	[SerializeField] DogoWalk dogoWalkScript;
	[SerializeField] GameObject dogosceneCamera;
	[SerializeField] GameObject dogopetGO;
	[SerializeField] Camera playerCamera;
	[SerializeField] LayerMask playerLayerMask;
	[SerializeField] Image fadeToBlackImage;
	[SerializeField] Color transparent;
	[SerializeField] Color black;
	[SerializeField] float triggerHeight;
	[SerializeField] float triggerRadius;
	Quaternion startRotation;
	bool playerDetected = false;
	bool playerLookedAt = false;
	bool dogGotPet = false;
	float timer = 0f;
	[SerializeField] float timerMultiplier = .33f;
	float smoothTime;
	void Start()
	{

	}

	// Update is called once per frame
	void FixedUpdate()
	{
		if(!playerDetected)
		{
			Collider[] hitColliders = new Collider[10];
			int numColliders = Physics.OverlapSphereNonAlloc(transform.position + transform.up * triggerHeight, triggerRadius, hitColliders, playerLayerMask);
			{
				for (int i = 0; i < numColliders; i++)
				{
					if(hitColliders[i].gameObject.CompareTag("Player"))
					{
						//Debug.Log($"Found player!");
						PlayerFound();
					}
				}
			}
		}
		if(playerDetected && !playerLookedAt && !dogGotPet)
		{
			// -(cos(PI * x) - 1) / 2 //Smooth in out
			smoothTime = (-(Mathf.Cos(Mathf.PI * timer) - 1) / 2);

			Quaternion lookAtDog = Quaternion.LookRotation(transform.position - dogosceneCamera.transform.position, Vector3.up);
			Debug.DrawRay(dogosceneCamera.transform.position, transform.position - dogosceneCamera.transform.position, Color.red, Time.deltaTime);
			dogosceneCamera.transform.rotation = Quaternion.Slerp(startRotation, lookAtDog, smoothTime);
			//Debug.Log($"slerping with smoothTime value {smoothTime}");
			fadeToBlackImage.color = Color.Lerp(transparent, black, timer);
			if(timer < 1f)
			{
				timer += Time.deltaTime * timerMultiplier;
			}
			else
			{
				PlayerLookedAt();
			}
		}
		if(playerDetected && playerLookedAt && !dogGotPet)
		{
			fadeToBlackImage.color = Color.Lerp(black, transparent, timer);
			if(timer < 1f)
			{
				timer += Time.deltaTime * timerMultiplier;
			}
		}
		if(dogGotPet)
		{
			fadeToBlackImage.color = Color.Lerp(transparent, black, timer);
			if(timer < 1f)
			{
				timer += Time.deltaTime * 0.6f; //attack of the magic numbers
				//Debug.Log($"gotpet timer: {timer}");
			}
			else
			{
				Debug.Log("<color=orange>end cutscene ended!!</color>");
			}
		}
	}

	void PlayerFound()
	{
		dogoWalkScript.DogFound();
		dogosceneCamera.transform.position = playerCamera.transform.position;
		dogosceneCamera.transform.rotation = playerCamera.transform.rotation;
		dogosceneCamera.transform.parent = null;
		startRotation = playerCamera.transform.rotation;
		playerDetected = true;
		dogosceneCamera.SetActive(true);
		playerCamera.gameObject.SetActive(false);
		fadeToBlackImage.enabled = true;
		fadeToBlackImage.color = transparent;
	}

	void PlayerLookedAt()
	{
		//Debug.Log($"Player looked at!");
		dogosceneCamera.SetActive(false);
		dogopetGO.SetActive(true);
		playerLookedAt = true;
		timer = 0f;
	}

	public void DogGotPet()
	{
		//Debug.Log($"Dog Got Pet got called!");
		timer = 0;
		dogGotPet = true;
	} 
}
