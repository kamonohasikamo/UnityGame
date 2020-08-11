using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultStarObjectController : MonoBehaviour
{
	public float startTime;
	void Start()
	{
		StartCoroutine(showStar());
	}

	IEnumerator showStar()
	{
		yield return new WaitForSeconds(startTime);
		foreach (Transform child in transform)
		{
			if(child.name == "ResultStarObject")
			{
				child.gameObject.SetActive(true);
			}
		}
	}

}
