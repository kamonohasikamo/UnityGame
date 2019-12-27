using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBlockController : MonoBehaviour
{
	// Blockの横幅を指定
	int blockHorizontalLength = 10;

	// 作成するwave最大値
	public static int maxWave = 5;
	// Blockの高さの最大値
	int blockMaxHight = 8;
	// ランダム用変数
	System.Random randamVariable = new System.Random();

	// blockの位置座標を動かす親オブジェクトの配列群
	GameObject[] parentBlock = new GameObject[maxWave];

	// ブロックの高さ各様用変数
	int blockHeight;

	// 各waveが進んでいいかどうかのFlag 
	bool[] isWaveMoving = new bool[maxWave];

	// wave move speed
	public float waveMoveSpeed = 1.0f;

	void Start()
	{
		GameManager.instance.setMaxWave(6);
		Debug.Log(GameManager.instance.getMaxWave());
		for (int i = 0; i < maxWave; i++)
		{
			int colorSelectRandom = randamVariable.Next(0, 3);
			createBlock(colorSelectRandom, i);
			isWaveMoving[i] = false;
		}
		isWaveMoving[0] = true;
	}

	
	void Update()
	{
		parentBlock[0].transform.Translate(-1 * waveMoveSpeed * Time.deltaTime, 0, 0);
		Debug.Log(parentBlock[0]);
	}

	void createBlock(int colorSelect, int waveNum)
	{
		parentBlock[waveNum] = (GameObject)Resources.Load("parentBlock");
		parentBlock[waveNum].name = "parentBlock" + waveNum.ToString();
		GameObject tmpParentObj = Instantiate(parentBlock[waveNum], new Vector2(10.0f, 0.0f), Quaternion.identity) as GameObject;
		switch(colorSelect)
		{
			case 0:
				for (int i = 0; i < blockHorizontalLength; i++)
				{
					GameObject redBlockObject = (GameObject)Resources.Load("redBlock");
					blockHeight = randamVariable.Next(1, blockMaxHight);
					redBlockObject.transform.localScale = new Vector3(1, blockHeight, 1);
					// Blockの位置調整
					float scaleY = (blockHeight == 1) ? 0.0f : (float)(blockHeight - 1) * 0.5f;
					
					GameObject tmpObject = Instantiate(redBlockObject, new Vector2(10.0f + (float)i, scaleY - 4.5f), Quaternion.identity) as GameObject;
					
					tmpObject.transform.parent = tmpParentObj.transform;
				}
				break;
			case 1:
				for (int i = 0; i < blockHorizontalLength; i++)
				{
					GameObject blueBlockObject = (GameObject)Resources.Load("blueBlock");
					blockHeight = randamVariable.Next(1, blockMaxHight);
					blueBlockObject.transform.localScale = new Vector3(1, blockHeight, 1);
					// Blockの位置調整
					float scaleY = (blockHeight == 1) ? 0.0f : (float)(blockHeight - 1) * 0.5f;
					
					GameObject tmpObject = Instantiate(blueBlockObject, new Vector2(10.0f + (float)i, scaleY - 4.5f), Quaternion.identity) as GameObject;
					
					tmpObject.transform.parent = tmpParentObj.transform;
				}
				break;
			case 2:
				for (int i = 0; i < blockHorizontalLength; i++)
				{
					GameObject greenBlockObject = (GameObject)Resources.Load("greenBlock");
					blockHeight = randamVariable.Next(1, blockMaxHight);
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
