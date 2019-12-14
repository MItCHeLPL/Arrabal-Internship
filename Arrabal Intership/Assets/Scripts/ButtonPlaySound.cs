using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPlaySound : MonoBehaviour
{
	[SerializeField]
	private AudioClip clickSound;

	[SerializeField]
	private Transform cam;

	public void PlaySound()
	{
		AudioSource.PlayClipAtPoint(clickSound, cam.position, DataHolder.Volume);
	}
}
