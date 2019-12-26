using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class toStartButton : MonoBehaviour
{
	public void OnClick()
	{
		SceneManager.LoadScene("Start");
	}
}
