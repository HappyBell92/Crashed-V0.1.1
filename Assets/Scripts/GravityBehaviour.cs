using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityBehaviour : MonoBehaviour
{
	public GameObject player;

	//public float rotationSpeed = 10f;

	public Quaternion fromRotation;
	public Transform from;
	public Transform up;
	public Transform down;
	public Transform north;
	public Transform south;
	public Transform east;
	public Transform west;

	public float speed = 0.25f;
	public float timePassedWait = 1f;
	public float gravityScale = 9.81f;
	float timeCount = 0.0f;


	/* void Start()
	{
		
	}

	private void Update()
	{
		if (Input.GetKey(KeyCode.G))
		{
			SwitchGravity("Up");
		}
	} */
	
	public void SwitchGravity(string cardinalDirection)
	{
		fromRotation = transform.rotation;
		switch (cardinalDirection)
		{
			case "Up": 
				StartCoroutine(RotatePlayer(Vector3.up, up.rotation));
				break;
			case "Down": 
				StartCoroutine(RotatePlayer(Vector3.down, down.rotation));
				break;
			case "North": 
				StartCoroutine(RotatePlayer(Vector3.forward, north.rotation));
				break;
			case "South": 
				StartCoroutine(RotatePlayer(Vector3.back, south.rotation));
				break;
			case "East": 
				StartCoroutine(RotatePlayer(Vector3.right, east.rotation));
				break;
			case "West": 
				StartCoroutine(RotatePlayer(Vector3.left, west.rotation));
				break;
			default:
				Debug.LogError(this+" given invalid gravity cardinal direction!");
				break;
		}
	}

	IEnumerator RotatePlayer(Vector3 gravityDirection, Quaternion endRotation)
	{
		Physics.gravity = gravityDirection * gravityScale;
		float timeCount = 0f;

		while (timeCount < 1f)
		{
			player.transform.rotation = Quaternion.Slerp(fromRotation, endRotation, timeCount);
			timeCount = timeCount + Time.deltaTime;

			yield return null;
		}
	}
}
