using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class showScoreController : MonoBehaviour
{
	private Text scoreText;
	void Start()
	{
		scoreText = this.GetComponent<Text>();
	}

	void Update()
	{
		scoreText.text = GameManager.instance.Score.ToString();
	}
}
