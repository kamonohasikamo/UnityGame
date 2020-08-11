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
    int typeMatch;

	public float NaturalDamage = 0.0f;
    public float TypeGoodHeal = 0.0f;
    public float TypeBadDamage = 0.0f;
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
		if (Mathf.Approximately(Time.timeScale, 0f))
		{
			return;
		}
		if (GameManager.instance.getIsCheat())
		{
			currentHp = 100;
		}
		else
		{
			if (GameManager.instance.getIsGameStart())
			{
				typeMatch = GameManager.instance.getPlayerStatus();
				GameManager.instance.setPlayerHP(currentHp);
				currentHp = GameManager.instance.getPlayerHP();
				slider.value = (float)currentHp / (float)maxHp;
				healCount = GameManager.instance.getHealItemCount();

				switch (typeMatch)
				{
					case 0:
						currentHp = currentHp + TypeGoodHeal;
						GameManager.instance.setPlayerHP(currentHp);
						break;
					case 1:
						break;
					case 2:
						currentHp = currentHp - TypeBadDamage;
						GameManager.instance.setPlayerHP(currentHp);
						break;
					case 3:
						currentHp = currentHp - NaturalDamage;
						GameManager.instance.setPlayerHP(currentHp);
						break;
				}

				if (healCount > 0)
				{
					healCount--;
					currentHp = currentHp + 13;
					GameManager.instance.setHealItemCount(healCount);
					GameManager.instance.setPlayerHP(currentHp);
				}
				else if(currentHp <= 0)
				{
					SceneManager.LoadScene("Result");
				}

				if(currentHp > 100)
				{
					currentHp = 100;
					GameManager.instance.setPlayerHP(100);
				}
			}
		}
	}
}