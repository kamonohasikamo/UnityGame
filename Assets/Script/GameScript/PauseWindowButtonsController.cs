using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseWindowButtonsController : MonoBehaviour
{
	#pragma warning disable 649
	[SerializeField]
	private GameObject pauseUI;
	#pragma warning restore 649

	public void onPressToTitleButton()
	{
		Time.timeScale = 1f;
		SceneManager.LoadScene("Start");
	}

	public void onPressReturnButton()
	{
		Time.timeScale = 1f;
		pauseUI.SetActive(!pauseUI.activeSelf);
	}
}
