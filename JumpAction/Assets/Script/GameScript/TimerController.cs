using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
	// ゲーム終了時、minuteとsecondsからトータル秒を計算すればいい
	// totalSeconds = minute * 60 + seconds;
	// 分
	[SerializeField]
	private int minute;
	// 秒
	[SerializeField]
	private float seconds;
	// Timer text
	private Text timerText;

	void Start()
	{
		minute = 0;
		seconds = 0f;
		timerText = GetComponentInChildren<Text>();
	}

	void Update()
	{
		minute = GameManager.instance.getGameMinute();
		seconds = GameManager.instance.getGameSeconds();
		seconds += Time.deltaTime;
		GameManager.instance.setGameSeconds(seconds);
		GameManager.instance.setGameMinute(minute);

		GameManager.instance.setGameTotalSeconds((minute * 60) + (int)seconds);
		if (seconds >= 60f)
		{
			minute++;
			seconds -= 60f;
			GameManager.instance.setGameSeconds(seconds);
			GameManager.instance.setGameMinute(minute);
			GameManager.instance.setGameTotalSeconds((minute * 60) + (int)seconds);
		}
		timerText.text = minute.ToString("00") + ":" + ((int)seconds).ToString("00");
	}
}
