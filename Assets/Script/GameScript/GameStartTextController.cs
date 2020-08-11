using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStartTextController : MonoBehaviour
{
	// 文字点滅速度
	public float FlashSpeed = 1.0f;

	public Text gameStartText;
	private float time;

	void Update()
	{
		gameStartText.color = GetAlphaColor(gameStartText.color);
	}

	Color GetAlphaColor(Color textColor)
	{
		time += Time.unscaledDeltaTime * 5.0f * FlashSpeed;
		textColor.a = Mathf.Sin(time) * 0.5f + 0.5f;

		return textColor;
	}
}
