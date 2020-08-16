using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
	// 非同期動作で使用
	private AsyncOperation async;

	// GameStart画面のUI
	[SerializeField]
	public GameObject startUI;

	// ロード画面で使用するUI
	[SerializeField]
	public GameObject loadUI;

	// ロード画面のスライダー
	[SerializeField]
	public Slider slider;
	
	public void ButtonClicked()
	{
		startUI.SetActive(false);
		loadUI.SetActive(true);
		StartCoroutine("LoadGame");
	}

	IEnumerator LoadGame()
	{
		yield return new WaitForSeconds(1f);
		if (PlayerPrefs.GetString("Name") != "")
		{
			async = SceneManager.LoadSceneAsync("Game");
		}
		else
		{
			async = SceneManager.LoadSceneAsync("InputName");
		}

		// 読み込みが終わるまで進捗状況をスライダーに送る
		while(!async.isDone)
		{
			var progressVal = Mathf.Clamp01(async.progress / 0.9f);
			slider.value = progressVal;
			yield return null;
		}


	}
}
