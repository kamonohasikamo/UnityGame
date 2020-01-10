using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class toGameButton : MonoBehaviour
{
	public void OnClick()
	{
		GameManager.instance.setIsCheat(false);
		SceneManager.LoadScene("Game");
	}
}
