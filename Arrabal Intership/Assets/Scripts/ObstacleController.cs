using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
	[SerializeField]
	private int pointsAdd = 10;
	[SerializeField]
	private int specialPointsAdd = 100;
	[SerializeField]
	private int pointsDamage = 5;

	[SerializeField]
	private AudioClip catchedSound;
	[SerializeField]
	private AudioClip catchedSpecialSound;
	[SerializeField]
	private AudioClip lostSound;

	private void OnTriggerEnter(Collider col)
	{
		GetComponent<Collider>().isTrigger = false;

		//trash hit good trashbin
		if(col.CompareTag(gameObject.tag))
		{
			//add points
			ScoreController.scoreController.AddPoints(pointsAdd);

			//play particles
			col.transform.GetComponentInChildren<ParticleSystem>().Play();

			//play audio
			AudioSource.PlayClipAtPoint(catchedSound, transform.position, DataHolder.Volume);

			//add stats depending on trash/bin
			switch (col.tag)
			{
				case "Yellow":
				{
					DataHolder.PlasticCatched++;
					break;
				}
				case "Green":
				{
					DataHolder.GlassCatched++;
					break;
				}
				case "Blue":
				{
					DataHolder.PaperCatched++;
					break;
				}
				default:
				{
					DataHolder.TrashLost++;
					break;
				}
			}
		}

		//if catched special
		else if(gameObject.tag == "Special" && !col.CompareTag("Floor") && !col.CompareTag("Untagged"))
		{
			ScoreController.scoreController.AddPoints(specialPointsAdd);
			ScoreController.scoreController.Heal(1);

			//play audio and particles
			col.transform.GetComponentInChildren<ParticleSystem>().Play();
			AudioSource.PlayClipAtPoint(catchedSpecialSound, transform.position, DataHolder.Volume);

			//stats
			DataHolder.SpecialCatched++;
		}

		//if trash lost
		else
		{
			if(col.CompareTag("Floor") == false)
			{
				DataHolder.TrashInWrongBin++;
			}
			ScoreController.scoreController.Damage(transform.position, pointsDamage);

			AudioSource.PlayClipAtPoint(lostSound, transform.position, DataHolder.Volume);
		}
		Destroy(gameObject);
	}
}