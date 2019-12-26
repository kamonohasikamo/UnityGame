using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemButtonController : MonoBehaviour
{
	[SerializeField]
	int redCount;
	[SerializeField]
	int blueCount;
	[SerializeField]
	int greenCount;

	GameObject redButton;
	GameObject blueButton;
	GameObject greenButton;

	void Start()
	{
		redCount = 0;
		blueCount = 0;
		greenCount = 0;
		redButton = transform.GetChild(0).gameObject;
		blueButton = transform.GetChild(1).gameObject;
		greenButton = transform.GetChild(2).gameObject;
	}

	void Update()
	{
		if (redCount <= 9)
		{
			redButton.GetComponentInChildren<Text>().text = "x" + redCount.ToString();
		}
		if (blueCount <= 9)
		{
			blueButton.GetComponentInChildren<Text>().text = "x" + blueCount.ToString();
		}
		if (greenCount <= 9)
		{
			greenButton.GetComponentInChildren<Text>().text = "x" + greenCount.ToString();
		}
	}

	public void OnClickRedButton()
	{
		redCount++;
	}

	public void OnClickBlueButton()
	{
		blueCount++;
	}

	public void OnClickGreenButton()
	{
		greenCount++;
	}
}
