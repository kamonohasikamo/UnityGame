using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;

public class PlayFabController : MonoBehaviour
{
	void Start()
	{
		PlayFabClientAPI.LoginWithCustomID(
			new LoginWithCustomIDRequest
			{
				TitleId = PlayFabSettings.TitleId,
				CustomId = "100",
				CreateAccount = true
			}
		, result =>
		{
			Debug.Log("sucess Login!");
		}
		, error =>
		{
			Debug.Log(error.GenerateErrorReport());
		});
	}
}
