using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstTouchPanelController : MonoBehaviour
{
	// Player Tap Panel
	public GameObject touchPanel;

	// Player Rigidbody2D
	public Rigidbody2D playerRB2D;

	// Player First FlapVelocity
	public float playerFirstFlapVelocity;

	void Awake()
	{
		touchPanel.SetActive(false);
		Time.timeScale = 0f;
	}

	void Start()
	{
		GameManager.instance.setIsGameStart(false);
	}

	public void OnPressFirstTouchPanel()
	{
		// 最初だけおまけの上向きベクトル
		playerRB2D.velocity = new Vector2(0.0f, playerFirstFlapVelocity);
		touchPanel.SetActive(true);
		GameManager.instance.setIsGameStart(true);
		Time.timeScale = 1f;
		GameObject parent = this.transform.parent.gameObject;
		parent.SetActive(false);
	}
}
