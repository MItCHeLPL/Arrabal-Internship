﻿using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneLoader : MonoBehaviour
{
    public void LoadScene(int id)
	{
		SceneManager.LoadScene(id);
	}
}
