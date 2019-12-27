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

	// 各waveが進んでいいかどうかのFlag 
	public static bool[] isWaveMoving = new bool[maxWave];
	
	public bool[] getIsWaveMoving()
	{
		return isWaveMoving;
	}

	public bool getOneIsWaveMoving(int getPoint)
	{
		return isWaveMoving[getPoint];
	}

	public void setOneIsWaveMoving(int setPoint, bool setFlag)
	{
		isWaveMoving[setPoint] = setFlag; 
	}

	public void setIsWaveMoving(bool[] setFlags)
	{
		isWaveMoving = setFlags;
	}

	// wave move speed
	public static float waveMoveSpeed = 1.0f;

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
	public static int playerHaveRedCount = 0;

	public int getPlayerHaveRedCount()
	{
		return playerHaveRedCount;
	}

	public void setPlayerHaveRedCount(int setValue)
	{
		playerHaveRedCount = setValue;
	}

	public static int playerHaveBlueCount = 0;

	public int getPlayerHaveBlueCount()
	{
		return playerHaveBlueCount;
	}

	public void setPlayerHaveBlueCount(int setValue)
	{
		playerHaveBlueCount = setValue;
	}

	public static int playerHaveGreenCount = 0;

	public int getPlayerHaveGreenCount()
	{
		return playerHaveGreenCount;
	}

	public void setPlayerHaveGreenCount(int setValue)
	{
		playerHaveGreenCount = setValue;
	}
}