using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using PlayFab;
using PlayFab.ClientModels;

public class onPressOkButton : MonoBehaviour
{
	public InputField inputNameField;
	public Text errorText;

	private bool isCreateAccount;
	private string customId;

	private string playerName = "とど1号";

	public void onClick()
	{
		GameManager.instance.setIsCheat(false);
		GameManager.instance.Score = 0;
		GameManager.instance.setItemUseCount(0);
		if (inputNameField.text != "")
		{
			playerName = inputNameField.text;
		}
		login();
	}

	private void login()
	{
		customId = createCustomId();
		var request = new LoginWithCustomIDRequest
		{
			CustomId = customId,
			CreateAccount = true,
		};
		PlayFabClientAPI.LoginWithCustomID(request, Success, Error);
	}

	private void Success(LoginResult result)
	{
		if (!result.NewlyCreated)
		{
			login();
			return;
		}

		if (result.NewlyCreated)
		{
			saveCustomId();
			setUserName();
		}
	}

	private void setUserName()
	{
		PlayerPrefs.SetString("Name", playerName);
		SceneManager.LoadScene("Game");
	}

	private void Error(PlayFabError error)
	{
		errorText.text = $"ERROR!\n{error.GenerateErrorReport()}";
	}

	private string createCustomId()
	{
		int idLength = 32;
		StringBuilder stringBuilder = new StringBuilder(idLength);
		var random = new System.Random();

		for (int i = 0; i < idLength; i++)
		{
			stringBuilder.Append(Define.ID_STRING[random.Next(Define.ID_STRING.Length)]);
		}

		return stringBuilder.ToString();
	}

	private void saveCustomId()
	{
		PlayerPrefs.SetString(Define.CUSTOM_ID_SAVE_KEY, customId);
	}
}
