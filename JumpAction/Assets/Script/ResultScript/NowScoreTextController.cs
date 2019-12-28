using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NowScoreTextController : MonoBehaviour
{
	private Text nowScoreText;
	void Start()
	{
		this.nowScoreText = GetComponent<Text>();
		// Score表示↓
		// this.nowScoreText.text += "<color=blue>" + + "</color>";
	}
}
