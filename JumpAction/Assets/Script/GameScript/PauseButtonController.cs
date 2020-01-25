using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButtonController : MonoBehaviour
{
	#pragma warning disable 649
	[SerializeField]
	private GameObject pauseUI;
	#pragma warning restore 649

	public void onPressPauseButton()
	{
		pauseUI.SetActive(!pauseUI.activeSelf);
		if (pauseUI.activeSelf)
		{
			Time.timeScale = 0.0f;
		}
	}
}
