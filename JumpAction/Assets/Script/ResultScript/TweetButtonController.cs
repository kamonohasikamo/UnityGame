using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Networking;
using UnityEngine.Networking;

public class TweetButtonController : MonoBehaviour
{
	public void OnPressTweetButton()
	{
		string message = "今回のスコアは\n" + GameManager.instance.getScore() + "でした！　#somatodo_games";
		Application.OpenURL("http://twitter.com/intent/tweet?text=" + UnityWebRequest.EscapeURL(message));
	}
}
