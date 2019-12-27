using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBlockController : MonoBehaviour
{
	// Blockの高さの最大値
	int blockMaxHight;
	// ランダム用変数
	System.Random randamVariable = new System.Random();

	// blockの位置座標を動かす親オブジェクトの配列群
	GameObject[] parentBlock = new GameObject[5];

	// ブロックの高さ格納用変数
	int blockHeight;

	void Start()
	{
		gameInit();
		for (int i = 0; i < GameManager.instance.getMaxWave(); i++)
		{
			int colorSelectRandom = randamVariable.Next(0, 3);
			createBlock(colorSelectRandom, i);
			GameManager.instance.setOneIsWaveMoving(i, false);
		}
		GameManager.instance.setOneIsWaveMoving(0, true);
	}

	void gameInit()
	{
		GameManager.instance.setBlockHorizontalLength(10);
		GameManager.instance.setBlockMaxHeight(8);
		GameManager.instance.setMaxWave(5);
		GameManager.instance.setWaveMoveSpeed(1.0f);
	}


	void Update()
	{
		parentBlock[0].transform.Translate(-1 * GameManager.instance.getWaveMoveSpeed() * Time.deltaTime, 0, 0);
	}

	void createBlock(int colorSelect, int waveNum)
	{
		parentBlock[waveNum] = (GameObject)Resources.Load("parentBlock");
		parentBlock[waveNum].name = "parentBlock" + waveNum.ToString();
		GameObject tmpParentObj = Instantiate(parentBlock[waveNum], new Vector2(10.0f, 0.0f), Quaternion.identity) as GameObject;
		switch(colorSelect)
		{
			case 0:
				for (int i = 0; i < GameManager.instance.getBlockHorizontalLength(); i++)
				{
					GameObject redBlockObject = (GameObject)Resources.Load("redBlock");
					blockHeight = randamVariable.Next(1, GameManager.instance.getBlockMaxHeight());
					redBlockObject.transform.localScale = new Vector3(1, blockHeight, 1);
					// Blockの位置調整
					float scaleY = (blockHeight == 1) ? 0.0f : (float)(blockHeight - 1) * 0.5f;
					
					GameObject tmpObject = Instantiate(redBlockObject, new Vector2(10.0f + (float)i, scaleY - 4.5f), Quaternion.identity) as GameObject;
					
					tmpObject.transform.parent = tmpParentObj.transform;
				}
				break;
			case 1:
				for (int i = 0; i < GameManager.instance.getBlockHorizontalLength(); i++)
				{
					GameObject blueBlockObject = (GameObject)Resources.Load("blueBlock");
					blockHeight = randamVariable.Next(1, GameManager.instance.getBlockMaxHeight());
					blueBlockObject.transform.localScale = new Vector3(1, blockHeight, 1);
					// Blockの位置調整
					float scaleY = (blockHeight == 1) ? 0.0f : (float)(blockHeight - 1) * 0.5f;
					
					GameObject tmpObject = Instantiate(blueBlockObject, new Vector2(10.0f + (float)i, scaleY - 4.5f), Quaternion.identity) as GameObject;
					
					tmpObject.transform.parent = tmpParentObj.transform;
				}
				break;
			case 2:
				for (int i = 0; i < GameManager.instance.getBlockHorizontalLength(); i++)
				{
					GameObject greenBlockObject = (GameObject)Resources.Load("greenBlock");
					blockHeight = randamVariable.Next(1, GameManager.instance.getBlockMaxHeight());
					greenBlockObject.transform.localScale = new Vector3(1, blockHeight, 1);
					// Blockの位置調整
					float scaleY = (blockHeight == 1) ? 0.0f : (float)(blockHeight - 1) * 0.5f;

					GameObject tmpObject = Instantiate(greenBlockObject, new Vector2(10.0f + (float)i, scaleY - 4.5f), Quaternion.identity) as GameObject;
					tmpObject.transform.parent = tmpParentObj.transform;
				}
				break;
		}
		parentBlock[waveNum] = tmpParentObj;
	}
}
