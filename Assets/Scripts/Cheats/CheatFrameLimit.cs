using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheatFrameLimit : MonoBehaviour
{
	[SerializeField] int fpsTarget = 30;
	[SerializeField] bool setFps = false;
	void Update()
	{
		if (setFps)
		{
			Application.targetFrameRate = fpsTarget;
			setFps = false;
		}
	}


}
