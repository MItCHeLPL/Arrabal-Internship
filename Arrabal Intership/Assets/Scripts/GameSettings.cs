using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings : MonoBehaviour
{
	[SerializeField]
	private int targetFrameRate = 60;
	void Start()
	{
		//capped fps
		Application.targetFrameRate = targetFrameRate;

		//vsync enabled
		QualitySettings.vSyncCount = 1;
	}
}
