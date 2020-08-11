using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheatButtonController : MonoBehaviour
{
	// 押した回数
	public int pressCount;

	// 閾値
	public int pressCountThreshold;
	void Start()
	{
		pressCount = 0;
	}

	public void OnPressCheatButton()
	{
		pressCount++;
	}

	void Update()
	{
		if (pressCount >= pressCountThreshold)
		{
			GameManager.instance.setIsCheat(true);
		}
		else
		{
			GameManager.instance.setIsCheat(false);
		}
	}
}
