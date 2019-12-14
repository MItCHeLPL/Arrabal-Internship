using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreController : MonoBehaviour
{
	private int scoreToHeal = 0;
	[SerializeField]
	private readonly int minScore = 0;
	[SerializeField]
	private int startHp = 5;

	public static ScoreController scoreController;
	public TextMeshProUGUI scoreTMPro;
	public TextMeshProUGUI hpTMPro;

	public GameObject damageParticle;

	private bool healed = false;

	private ObstacleSpawner obstacleSpawner;

	private float startTime;

	[SerializeField]
	private Transform trashBackground;

	private bool moved = false;
	private bool minutesAdded = false;

	[SerializeField]
	private float riseTrash = 4.875f;
	void Awake()
	{
		scoreController = this; //singleton

		obstacleSpawner = GetComponent<ObstacleSpawner>();

		TryAgain();

		RefreshScore();
		RefreshHp();

		startTime = Time.time;
	}

	private void Update()
	{
		//minutes and seconds
		if(((int)((Time.time - startTime) % 60)) >= 59 && minutesAdded == false)
		{
			DataHolder.TimeSurvivedMin++;
			minutesAdded = true;
		}
		else if(((int)((Time.time - startTime) % 60)) == 0 && minutesAdded == true)
		{
			minutesAdded = false;
		}

		//objects fall faster
		if (DataHolder.Score >= 300 && DataHolder.Score < 600)
		{
			obstacleSpawner.waitTimerStartValue = 1.5f;
		}
		else if (DataHolder.Score >= 600)
		{
			obstacleSpawner.waitTimerStartValue = 1.25f;
		}

		//end game
		if (DataHolder.Hp <= 0)
		{
			DataHolder.TimeSurvivedSec = (int)((Time.time - startTime) % 60);
			SceneManager.LoadScene(2);
		}

		//heal every 10 catched objects
		if (scoreToHeal % 100 == 0 && healed == false && scoreToHeal > 0)
		{
			Heal(1);
			healed = true;
		}
		if (scoreToHeal % 100 != 0 && healed == true)
		{
			healed = false;
		}
	}

	//refresh stats ui
	public void RefreshScore()
	{
		scoreTMPro.SetText("Score: {0}", DataHolder.Score);
	}

	public void RefreshHp()
	{
		hpTMPro.SetText("HP: {0}", DataHolder.Hp);
	}

	//heal
	public void Heal(int amount)
	{
		StartCoroutine(TrashMovement(8.0f, new Vector3(trashBackground.position.x, trashBackground.position.y - riseTrash, trashBackground.position.z)));
		DataHolder.Hp += amount;
		RefreshHp();
	}

	//damage
	public void Damage(Vector3 position, int damage)
	{
		if (DataHolder.Score > minScore)
		{
			DataHolder.Score -= damage;
			RefreshScore();
		}
		DataHolder.Hp -= 1;
		scoreToHeal = 0;
		RefreshHp();
		DataHolder.TrashLost++;
		if (DataHolder.Hp > 0)
		{
			StartCoroutine(TrashMovement(8.0f, new Vector3(trashBackground.position.x, trashBackground.position.y + riseTrash, trashBackground.position.z)));
		}

		damageParticle.transform.position = position;
		damageParticle.GetComponent<ParticleSystem>().Play();
	}

	//add score
	public void AddPoints(int points)
	{
		DataHolder.Score += points;
		scoreToHeal += points;
		RefreshScore();
	}

	//reset stats
	public void TryAgain()
	{
		DataHolder.Score = minScore;
		scoreToHeal = minScore;
		DataHolder.Hp = startHp;
		DataHolder.TrashLost = 0;
		DataHolder.PaperCatched = 0;
		DataHolder.GlassCatched = 0;
		DataHolder.PlasticCatched = 0;
		startTime = Time.time;
		DataHolder.TimeSurvivedSec = 0;
		DataHolder.TimeSurvivedMin = 0;
		DataHolder.TrashInWrongBin = 0;
		DataHolder.SpecialCatched = 0;
	}

	//move trash background
	private IEnumerator TrashMovement(float speed, Vector3 endPoint)
	{
		moved = false;

		while (moved == false)
		{
			trashBackground.position = Vector3.MoveTowards(trashBackground.position, endPoint, speed * Time.deltaTime);
			if (Vector3.Distance(trashBackground.transform.position, endPoint) < 0.1f)
			{
				moved = true;
			}
			yield return new WaitForEndOfFrame();
		}
	}
}
