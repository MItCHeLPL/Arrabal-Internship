
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SliderValue : MonoBehaviour
{
	private TextMeshProUGUI val;
	private Slider slider;

	void Start()
	{
		val = GetComponent<TextMeshProUGUI>();
		slider = transform.parent.GetComponent<Slider>();
		slider.value = DataHolder.Volume;
		val.SetText("{0:2}", slider.value);
	}

	//update slider caption
	public void UpdateText(TextMeshProUGUI text)
	{
		text.SetText("{0:2}", DataHolder.Volume);
	}

	//sets value slider
	public void UpdateVal(Slider slide)
	{
		DataHolder.Volume = slide.value;
	}
}