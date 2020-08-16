using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class onPressOkButton : MonoBehaviour
{
	public InputField inputNameField;

	public void onClick()
	{
		GameManager.instance.setIsCheat(false);
		GameManager.instance.Score = 0;
		GameManager.instance.setItemUseCount(0);
		if (inputNameField.text != "")
		{
			PlayerPrefs.SetString("Name", inputNameField.text);
		}
		else
		{
			PlayerPrefs.SetString("Name", "とど1号");
		}
		SceneManager.LoadScene("Game");
	}
}
