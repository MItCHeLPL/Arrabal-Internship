using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
	[SerializeField]
	private float rotationsPerMinute = 45.0f;
    void Update()
    {
		//rotate trash when falling
		transform.Rotate(0.0f, 0.0f, 6.0f * rotationsPerMinute * Time.deltaTime);
	}
}
