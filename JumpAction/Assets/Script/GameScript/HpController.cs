using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//UI使うときは忘れずに。
using UnityEngine.UI;

public class HpController : MonoBehaviour
{
	//最大HPと現在のHP。
	float maxHp;
	float currentHp;
	int healCount;

	public float NaturalDamege = 0.01f;
	//Sliderを入れる
	public Slider slider;

	void Start()
	{
		//Sliderを満タンにする。
		slider.value = 1;
		//現在のHPを最大HPと同じに。
		maxHp = GameManager.instance.getPlayerHP();
		currentHp = maxHp;
	}

	void Update()
	{
		if (GameManager.instance.getIsGameStart())
		{
			currentHp = currentHp - NaturalDamege;
			GameManager.instance.setPlayerHP(currentHp);
			currentHp = GameManager.instance.getPlayerHP();
			slider.value = (float)currentHp / (float)maxHp;
			healCount = GameManager.instance.getHealItemCount();
			if(healCount > 0)
			{
				healCount--;
				currentHp = currentHp + 10;
				GameManager.instance.setHealItemCount(healCount);
				GameManager.instance.setPlayerHP(currentHp);
			}
			if(currentHp <= 0)
			{
				SceneManager.LoadScene("Result");
			}
		}
	}
}