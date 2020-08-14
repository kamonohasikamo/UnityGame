using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBlockController : MonoBehaviour
{
	// ブロック初期x座標
	public float setBlockFirstXPoint;
	// Blockの高さの最大値
	int blockMaxHight;
	// ランダム用変数
	System.Random randamVariable = new System.Random();

	// blockの位置座標を動かす親オブジェクトの配列群
	GameObject[] parentBlock = new GameObject[5];

	// ブロックの高さ格納用変数
	int blockHeight;

	// ランダムな色を格納する変数
	int colorSelectRandom;

	// block 上部に設置するかどうかをいれる変数
	// 0-6 : 何もなし
	// 7,8 : 色変えアイテム
	// 9   : 回復アイテム
	int isSetBlockAbove;

	// 色変えアイテムをセットする場合、どの色のアイテムを出すか
	int setColorRandomNum;

	// 色変えアイテムのパス管理
	Dictionary<int, string> setItemPath = new Dictionary<int, string>()
	{
		{0, "Item/ColorItemRed"},
		{1, "Item/ColorItemBlue"},
		{2, "Item/ColorItemGreen"},
		{3, "Item/HealItem"} // 回復アイテムのパスを入れる
	};

	// 上部にセットするアイテムを格納する変数
	GameObject setBlockAboveItem;
	void Start()
	{
		gameInit();
		for (int i = 0; i < GameManager.instance.MaxWave; i++)
		{
			colorSelectRandom = randamVariable.Next(0, 3);
			createBlock(colorSelectRandom, i);
		}
	}

	void gameInit()
	{
		GameManager.instance.BlockHorizontalLength = 10;
		GameManager.instance.BlockMaxHeight = 8;
		GameManager.instance.MaxWave = 5;
		GameManager.instance.setWaveMoveSpeed(2.0f);
		GameManager.instance.setMovingBlock(0);
		GameManager.instance.setPlayerHP(100);
		GameManager.instance.setGameMinute(0);
		GameManager.instance.setGameSeconds(0);
		GameManager.instance.setGameTotalSeconds(0);
		GameManager.instance.setPlayerHaveRedCount(0);
		GameManager.instance.setPlayerHaveBlueCount(0);
		GameManager.instance.setPlayerHaveGreenCount(0);
		GameManager.instance.setPlayerStatus(3);
		GameManager.instance.setItemUseCount(0);
		isSetBlockAbove = 0;
		setColorRandomNum = 0;
	}


	void Update()
	{
		parentBlock[((GameManager.instance.getMovingBlock()) % 5)].transform.Translate(-1 * GameManager.instance.getWaveMoveSpeed() * Time.deltaTime, 0, 0);

		// create Block タイミング設定
		if (parentBlock[((GameManager.instance.getMovingBlock()) % 5)].transform.position.x < -6)
		{
			parentBlock[((GameManager.instance.getMovingBlock() + 1) % 5)].transform.Translate(-1 * GameManager.instance.getWaveMoveSpeed() * Time.deltaTime, 0, 0);
		}
		if (parentBlock[((GameManager.instance.getMovingBlock() + 1) % 5)].transform.position.x < -6)
		{
			parentBlock[((GameManager.instance.getMovingBlock() + 2) % 5)].transform.Translate(-1 * GameManager.instance.getWaveMoveSpeed() * Time.deltaTime, 0, 0);
		}
		if (parentBlock[((GameManager.instance.getMovingBlock()) % 5)].transform.position.x < -20)
		{
			Destroy(parentBlock[((GameManager.instance.getMovingBlock()) % 5)]);
			colorSelectRandom = randamVariable.Next(0, 3);
			createBlock(colorSelectRandom, ((GameManager.instance.getMovingBlock()) % 5));
			GameManager.instance.setMovingBlock(GameManager.instance.getMovingBlock() + 1);
		}

		// wave Speed (Level Design)
		if ((int)GameManager.instance.getGameTotalSeconds() >= 30 && (int)GameManager.instance.getGameTotalSeconds() < 60)
		{
			GameManager.instance.setWaveMoveSpeed(3.0f);
		}
		else if (GameManager.instance.getGameTotalSeconds() >= 60 && GameManager.instance.getGameTotalSeconds() < 90)
		{
			GameManager.instance.setWaveMoveSpeed(4.0f);
		}
		else if (GameManager.instance.getGameTotalSeconds() >= 90 && GameManager.instance.getGameTotalSeconds() < 120)
		{
			GameManager.instance.setWaveMoveSpeed(5.0f);
		}
		else if(GameManager.instance.getGameTotalSeconds() >= 120 && GameManager.instance.getGameTotalSeconds() < 150)
		{
			GameManager.instance.setWaveMoveSpeed(6.0f);
		}
		else if(GameManager.instance.getGameTotalSeconds() >= 150 && GameManager.instance.getGameTotalSeconds() < 180)
		{
			GameManager.instance.setWaveMoveSpeed(7.5f);
		}
		else if (GameManager.instance.getGameTotalSeconds() >= 180)
		{
			GameManager.instance.setWaveMoveSpeed(9.0f);
		}

	}

	// create Block
	// colorSelect : red, blue or green.
	//		red  : 0,
	//		blue : 1,
	//		green: 2
	// waveNum : wave Number
	void createBlock(int colorSelect, int waveNum)
	{
		parentBlock[waveNum] = (GameObject)Resources.Load("parentBlock");
		parentBlock[waveNum].name = "parentBlock" + waveNum.ToString();
		GameObject tmpParentObj = Instantiate(parentBlock[waveNum], new Vector2(10.0f, 0.0f), Quaternion.identity) as GameObject;
		int createSpaceRandom = randamVariable.Next(0, 100);
		float createSpace;
		if (createSpaceRandom >= 30 && createSpaceRandom <= 80)
		{
			createSpace = 2.0f;
		}
		else if (createSpaceRandom > 80)
		{
			createSpace = 4.0f;
		}
		else
		{
			createSpace = 0.0f;
		}
		
		switch(colorSelect)
		{
			// red
			case 0:
				for (int i = 0; i < GameManager.instance.BlockHorizontalLength; i++)
				{
					GameObject redBlockObject = (GameObject)Resources.Load("redBlock");
					blockHeight = randamVariable.Next(1, GameManager.instance.BlockMaxHeight);
					redBlockObject.transform.localScale = new Vector3(1, blockHeight, 1);
					// Blockの位置調整
					float scaleY = (blockHeight == 1) ? 0.0f : (float)(blockHeight - 1) * 0.5f;

					// ブロックの上にアイテムを置く処理
					setAboveItem((float)i + createSpace, blockHeight, tmpParentObj);

					GameObject tmpObject = Instantiate(redBlockObject, new Vector2(setBlockFirstXPoint + (float)i + createSpace, scaleY - 4.5f), Quaternion.identity) as GameObject;
					
					tmpObject.transform.parent = tmpParentObj.transform;
				}
				break;
			// blue
			case 1:
				for (int i = 0; i < GameManager.instance.BlockHorizontalLength; i++)
				{
					GameObject blueBlockObject = (GameObject)Resources.Load("blueBlock");
					blockHeight = randamVariable.Next(1, GameManager.instance.BlockMaxHeight);
					blueBlockObject.transform.localScale = new Vector3(1, blockHeight, 1);
					// Blockの位置調整
					float scaleY = (blockHeight == 1) ? 0.0f : (float)(blockHeight - 1) * 0.5f;

					// ブロックの上にアイテムを置く処理
					setAboveItem((float)i + createSpace, blockHeight, tmpParentObj);

					GameObject tmpObject = Instantiate(blueBlockObject, new Vector2(setBlockFirstXPoint + (float)i + createSpace, scaleY - 4.5f), Quaternion.identity) as GameObject;
					
					tmpObject.transform.parent = tmpParentObj.transform;
				}
				break;
			// green
			case 2:
				for (int i = 0; i < GameManager.instance.BlockHorizontalLength; i++)
				{
					GameObject greenBlockObject = (GameObject)Resources.Load("greenBlock");
					blockHeight = randamVariable.Next(1, GameManager.instance.BlockMaxHeight);
					greenBlockObject.transform.localScale = new Vector3(1, blockHeight, 1);
					// Blockの位置調整
					float scaleY = (blockHeight == 1) ? 0.0f : (float)(blockHeight - 1) * 0.5f;

					// ブロックの上にアイテムを置く処理
					setAboveItem((float)i + createSpace, blockHeight, tmpParentObj);

					GameObject tmpObject = Instantiate(greenBlockObject, new Vector2(setBlockFirstXPoint + (float)i + createSpace, scaleY - 4.5f), Quaternion.identity) as GameObject;
					tmpObject.transform.parent = tmpParentObj.transform;
				}
				break;
		}
		parentBlock[waveNum] = tmpParentObj;
	}

	// set Block Above Item
	void setAboveItem(float setPosX_i, int blockHeight, GameObject parent)
	{
		isSetBlockAbove = randamVariable.Next(0, 10);
		float scaleY = (blockHeight == 1)? - 3.7f : -3.7f + (float)(blockHeight - 1);
		if(isSetBlockAbove == 7 || isSetBlockAbove == 8)
		{
			setColorRandomNum = randamVariable.Next(0, 3);
			setBlockAboveItem = (GameObject)Resources.Load(setItemPath[setColorRandomNum]);
			GameObject tmp = Instantiate(setBlockAboveItem, new Vector2(setBlockFirstXPoint + setPosX_i, scaleY), Quaternion.identity) as GameObject;
			tmp.transform.parent = parent.transform;
		}
		else if (isSetBlockAbove == 9)
		{
			setBlockAboveItem = (GameObject)Resources.Load(setItemPath[3]);
			GameObject tmp = Instantiate(setBlockAboveItem, new Vector2(setBlockFirstXPoint + setPosX_i, scaleY), Quaternion.identity) as GameObject;
			tmp.transform.parent = parent.transform;
		}
	}
}
