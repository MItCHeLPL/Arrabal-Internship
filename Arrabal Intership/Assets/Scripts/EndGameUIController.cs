using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class EndGameUIController : MonoBehaviour
{
	[SerializeField]
	private TextMeshProUGUI val;
	void Start()
	{
		//minutes
		if(DataHolder.TimeSurvivedMin < 10)
		{
			val.text = "0" + DataHolder.TimeSurvivedMin + ":";
		}
		else
		{
			val.text = DataHolder.TimeSurvivedMin + ":";
		}

		//seconds
		if(DataHolder.TimeSurvivedSec < 10)
		{
			val.text += "0" + DataHolder.TimeSurvivedSec;
		}
		else
		{
			val.text += DataHolder.TimeSurvivedSec;
		}

		//other stats
		val.text += "\n" + DataHolder.Score + "\n" + (DataHolder.GlassCatched + DataHolder.PlasticCatched + DataHolder.PaperCatched) + "\n" + DataHolder.SpecialCatched + "\n" + DataHolder.PlasticCatched + "\n" + DataHolder.GlassCatched + "\n" + DataHolder.PaperCatched + "\n" + DataHolder.TrashLost + "\n" + DataHolder.TrashInWrongBin;
	}
}