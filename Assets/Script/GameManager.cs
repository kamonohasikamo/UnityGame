using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	//=============================================
	// GameManager instance
	//=============================================
	public static GameManager instance = null;

	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
			DontDestroyOnLoad(this.gameObject);
		}
		else
		{
			Destroy(this.gameObject);
		}
	}

	void Update()
	{
		score = (gameMinute * 60 + (int)gameSeconds) * 100 + itemUseCount * 100 - (int)playerFlyTime;
	}

	//=============================================
	// use CreateBlockController variable
	//=============================================

	// Block の高さの最大値
	public int blockMaxHeight = 8;

	public int getBlockMaxHeight()
	{
		return blockMaxHeight;
	}
	
	public void setBlockMaxHeight(int setValue)
	{
		blockMaxHeight = setValue;
	}


	// Block の横サイズ
	public int blockHorizontalLength = 10;
	
	public int getBlockHorizontalLength()
	{
		return blockHorizontalLength;
	}

	public void setBlockHorizontalLength(int setValue)
	{
		blockHorizontalLength = setValue;
	}

	// waveの最大値
	public static int maxWave = 5;

	public int getMaxWave()
	{
		return maxWave;
	}

	public void setMaxWave(int setValue)
	{
		maxWave = setValue;
	}

	// 今動いているブロックを管理
	public int movingBlock;

	public int getMovingBlock()
	{
		return movingBlock;
	}

	public void setMovingBlock(int setValue)
	{
		movingBlock = setValue;
	}

	// wave move speed
	public float waveMoveSpeed = 1.0f;

	public float getWaveMoveSpeed()
	{
		return waveMoveSpeed;
	}

	public void setWaveMoveSpeed(float setValue)
	{
		waveMoveSpeed = setValue;
	}

	//=============================================
	// use ItemButtonController variable and more?
	//=============================================
	public int playerHaveRedCount = 0;

	public int getPlayerHaveRedCount()
	{
		return playerHaveRedCount;
	}

	public void setPlayerHaveRedCount(int setValue)
	{
		playerHaveRedCount = setValue;
	}

	public int playerHaveBlueCount = 0;

	public int getPlayerHaveBlueCount()
	{
		return playerHaveBlueCount;
	}

	public void setPlayerHaveBlueCount(int setValue)
	{
		playerHaveBlueCount = setValue;
	}

	public int playerHaveGreenCount = 0;

	public int getPlayerHaveGreenCount()
	{
		return playerHaveGreenCount;
	}

	public void setPlayerHaveGreenCount(int setValue)
	{
		playerHaveGreenCount = setValue;
	}

	//タイマーの分と秒
	//=============================================
	// use TimerController variable and more?
	//=============================================
	public int gameMinute = 0;

	public int getGameMinute()
	{
		return gameMinute;
	}

	public void setGameMinute(int setValue)
	{
		gameMinute = setValue;
	}

	public float gameSeconds = 0;

	public float getGameSeconds()
	{
		return gameSeconds;
	}

	public void setGameSeconds(float setValue)
	{
		gameSeconds = setValue;
	}

	public int gameTotalSeconds = 0;

	public int getGameTotalSeconds()
	{
		return gameTotalSeconds;
	}

	public void setGameTotalSeconds(int setValue)
	{
		gameTotalSeconds = setValue;
	}

	//=============================================
	// Player
	//=============================================
	//スコア
	private int score = 0;

	public int Score
	{
		set
		{
			this.score = value;
		}
		get
		{
			return score;
		}
	}

	//浮遊時間
	public float playerFlyTime = 0.0f;

	public float getPlayerFlyTime()
	{
		return playerFlyTime;
	}

	public void setPlayerFlyTime(float setValue)
	{
		playerFlyTime = setValue;
	}

	//アイテムの使用回数
	public int itemUseCount = 0;

	public int getItemUseCount()
	{
		return itemUseCount;
	}

	public void setItemUseCount(int setValue)
	{
		itemUseCount = setValue;
	}

	//HP
	public float playerHP = 100;

	public float getPlayerHP()
	{
		return playerHP;
	}

	public void setPlayerHP(float setValue)
	{
		playerHP = setValue;
	}

	public int healItemcount = 0;

	public int getHealItemCount()
	{
		return healItemcount;
	}

	public void setHealItemCount(int setValue)
	{
		healItemcount = setValue;
	}

	//=============================================
	// GameStart Flag
	//=============================================
	public bool isGameStart = false;

	public bool getIsGameStart()
	{
		return isGameStart;
	}

	public void setIsGameStart(bool setFlag)
	{
		isGameStart = setFlag;
	}

   //PlayerColoerCheck
    public int playerStatus = 3;

    public int getPlayerStatus()
    {
        return playerStatus;
    }

    public void setPlayerStatus(int setValue)
    {
        playerStatus = setValue;
    }
	// Player Cheat Flag
	public bool isCheat = false;
	public bool getIsCheat()
	{
		return isCheat;
	}

	public void setIsCheat(bool setFlag)
	{
		isCheat = setFlag;
	}
}