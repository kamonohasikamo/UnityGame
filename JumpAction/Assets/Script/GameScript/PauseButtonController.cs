using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButtonController : MonoBehaviour
{
	[SerializeField]
	private GameObject pauseUI;

	public void onPressPauseButton()
	{
		pauseUI.SetActive(!pauseUI.activeSelf);
		if (pauseUI.activeSelf)
		{
			Time.timeScale = 0.0f;
		}
	}
}
