using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
	[SerializeField]
	private List<GameObject> obstaclesPrefab = new List<GameObject>();
	[SerializeField]
	private GameObject specialPrefab;
	private List<GameObject> obstacles = new List<GameObject>();
	
	[SerializeField]
	private float maxObstaclesAmount = 1;

	[SerializeField]
	private Vector3 spawnBoundries = new Vector3(-3.25f, 8.0f, 3.25f);

	public float waitTimerStartValue = 2.0f;
	public float waitTimer;

	private int specialCounter = 0;

	private void Start()
	{
		waitTimer = waitTimerStartValue;
	}

	void FixedUpdate()
    {
		//object cooldown
		if(waitTimer > 0)
		{
			waitTimer -= Time.deltaTime;
		}

		//max obstacles on screen
		if(obstacles.Count == maxObstaclesAmount)
		{
			obstacles.Clear();
		}

		//spawn obstacle
		if (obstacles.Count < maxObstaclesAmount && waitTimer <= 0)
		{
			SpawnObstacles(spawnBoundries.x, spawnBoundries.y, spawnBoundries.z);
		}
	}

	private void SpawnObstacles(float left, float height, float right)
	{
		//special
		if(Random.Range(1,10) == 7 && specialCounter > 10)
		{
			obstacles.Add(Instantiate(specialPrefab, new Vector3(Random.Range(left, right), height, 0.0f), Quaternion.identity));
			specialCounter = 0;
		}

		//normal trash
		else
		{
			obstacles.Add(Instantiate(obstaclesPrefab[Random.Range(0, obstaclesPrefab.Count)], new Vector3(Random.Range(left, right), height, 0.0f), Quaternion.identity));
			specialCounter++;
		}
		waitTimer = waitTimerStartValue;
	}
}