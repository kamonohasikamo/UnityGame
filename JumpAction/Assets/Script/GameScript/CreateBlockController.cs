using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBlockController : MonoBehaviour
{
	// Blockの横幅を指定
	int blockHorizontalLength = 5;
	// ランダム用変数
	System.Random randamVariable = new System.Random();

	// ブロックの高さ各様用変数
	int blockHeight;
	void Start()
	{
		for (int i = 1; i < blockHorizontalLength; i++)
		{
			GameObject redBlockObject = (GameObject)Resources.Load("redBlock");
			blockHeight = randamVariable.Next(1, 5);
			redBlockObject.transform.localScale = new Vector3(1, blockHeight, 1);
			// Blockの位置調整
			float scaleY = (blockHeight == 1) ? 0.0f : (float)(blockHeight - 1) * 0.5f;
			Instantiate(redBlockObject, new Vector2(10.0f + (float)i, scaleY), Quaternion.identity);
		}
	}

	
	void Update()
	{
		
	}
}
