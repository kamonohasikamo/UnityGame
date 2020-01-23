using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseWindowButtonsController : MonoBehaviour
{
	[SerializeField]
	private GameObject pauseUI;
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
