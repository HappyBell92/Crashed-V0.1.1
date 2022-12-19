using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogPetEvent : MonoBehaviour
{
	[SerializeField] DogosceneTrigger dogoscene;
	public void StartEndFade()
	{
		//Debug.Log($"End fade event!");
		dogoscene.DogGotPet();
	}
}
