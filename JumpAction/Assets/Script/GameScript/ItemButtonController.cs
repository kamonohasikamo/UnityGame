using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemButtonController : MonoBehaviour
{
	[SerializeField]
	int redCount;
	[SerializeField]
	int blueCount;
	[SerializeField]
	int greenCount;

	GameObject redButton;
	GameObject blueButton;
	GameObject greenButton;

    public GameObject player;

	void Start()
	{
		redCount = 0;
		blueCount = 0;
		greenCount = 0;
		redButton = transform.GetChild(0).gameObject;
		blueButton = transform.GetChild(1).gameObject;
		greenButton = transform.GetChild(2).gameObject;
	}

	void Update()
	{
		if (redCount <= 9)
		{
			redButton.GetComponentInChildren<Text>().text = "x" + GameManager.instance.getPlayerHaveRedCount().ToString();
		}
		if (blueCount <= 9)
		{
			blueButton.GetComponentInChildren<Text>().text = "x" + GameManager.instance.getPlayerHaveBlueCount().ToString();
		}
		if (greenCount <= 9)
		{
			greenButton.GetComponentInChildren<Text>().text = "x" + GameManager.instance.getPlayerHaveGreenCount().ToString();
		}
	}

	public void OnClickRedButton()
	{
        redCount = GameManager.instance.getPlayerHaveRedCount();
  
        if ( redCount > 0)
        {
            redCount--;
            GameManager.instance.setPlayerHaveRedCount(redCount);
            player.GetComponent<Renderer>().material.color = Color.red;
        }
	}

	public void OnClickBlueButton()
	{
        blueCount = GameManager.instance.getPlayerHaveBlueCount();
        if (blueCount > 0)
        {
            blueCount--;
            GameManager.instance.setPlayerHaveBlueCount(blueCount);
            player.GetComponent<Renderer>().material.color = Color.blue;
        }
    }

	public void OnClickGreenButton()
	{
        greenCount = GameManager.instance.getPlayerHaveGreenCount();
        if (greenCount > 0)
        {
            greenCount--;
            GameManager.instance.setPlayerHaveGreenCount(greenCount);
            player.GetComponent<Renderer>().material.color = Color.green;
        }
    }
}
