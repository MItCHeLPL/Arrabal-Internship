using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
	public GameObject mainMenuPanel;
	public GameObject helpPanel;
	public GameObject settingsPanel;
	public GameObject authorsPanel;

	void Start()
	{
		mainMenuPanel.SetActive(true);
		helpPanel.SetActive(false);
		settingsPanel.SetActive(false);
		authorsPanel.SetActive(false);
	}

	public void HelpButton()
	{
		mainMenuPanel.SetActive(false);
		helpPanel.SetActive(true);
	}
	public void AuthorsButton()
	{
		mainMenuPanel.SetActive(false);
		authorsPanel.SetActive(true);
	}

	public void SettingsButton()
	{
		mainMenuPanel.SetActive(false);
		settingsPanel.SetActive(true);
	}

	public void ArrabalButton()
	{
		Application.OpenURL("http://asociacionarrabal.org/");
	}

	//return
	public void BackButton(GameObject prevPanel)
	{
		mainMenuPanel.SetActive(false);
		helpPanel.SetActive(false);
		settingsPanel.SetActive(false);
		authorsPanel.SetActive(false);
		prevPanel.SetActive(true);
	}

	//return on esc
	private void Update()
	{
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			BackButton(mainMenuPanel);
		}
	}
}