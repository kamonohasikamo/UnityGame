using UnityEngine;
using System;
using System.IO;
using System.Collections;
using UnityEngine.UI;

[Serializable]
public class InputMaster
{
	// Masterの配列の名前と一致している必要がある
	public Data[] Master;
	public int Length;
}

[Serializable]
public class Data
{
	// 各キーも一致させる必要がある
	public int pageId;
	public string description;
	public bool isImage;
	public string imagePath;
	public string imagePath2;
	public string imagePath3;
	public int positionNum;
	public int positionNum2;
	public int positionNum3;
}

public class DescriptionMaster : MonoBehaviour
{
	// 読み込んだテキストを出力するUIテキスト
	public Text dataText;

	// ページ番号を表示させるUIテキスト
	public Text countText;

	// 表示させる画像オブジェクト格納用
	public RawImage[] showImageObject;

	// Master
	InputMaster masterJson;

	// 今見ているページID
	public int nowPageId;

	// File Path
	const string MASTER_FILE_PATH = "DescriptionMaster/DescriptionMaster";

	void Start()
	{
		dataText = this.gameObject.GetComponent<Text>();
		// String型としてマスタデータの読み込み
		string inputString = Resources.Load<TextAsset>(MASTER_FILE_PATH).ToString();
		// JSONからオブジェクトを生成
		// この時、上記で宣言したクラスを使用する
		masterJson = JsonUtility.FromJson<InputMaster>(inputString);

		nowPageId = 0;
		dataText.text = masterJson.Master[nowPageId].description;
		allSetActiveFalse();
	}

	void Update()
	{
		int showPageId = (nowPageId == 0) ? 1 : (nowPageId + 1);
		countText.text = "(" + showPageId + "/" + masterJson.Length + ")";
		if (masterJson.Master[nowPageId].isImage)
		{
			setImage(true);
		}
	}

	public void OnPressNextButton()
	{
		if (masterJson.Master[nowPageId].isImage)
		{
			setImage(false);
		}
		if (nowPageId < masterJson.Length - 1)
		{
			nowPageId++;
		}
		else
		{
			nowPageId = 0;
		}
		dataText.text = masterJson.Master[nowPageId].description;
		
	}

	public void OnPressPrevButton()
	{
		if (masterJson.Master[nowPageId].isImage)
		{
			setImage(false);
		}
		if (nowPageId > 0)
		{
			nowPageId--;
		}
		else
		{
			nowPageId = masterJson.Length - 1;
		}
		dataText.text = masterJson.Master[nowPageId].description;
	}

	// positionNum == 0 はnullとして扱う
	void setImage(bool isSetActive)
	{
		if (isSetActive)
		{
			// 1つ目は必ずある(isSetActiveをtrueにしているので)
			int objNum = masterJson.Master[nowPageId].positionNum - 1;
			showImageObject[objNum].texture = (Texture2D)Resources.Load(masterJson.Master[nowPageId].imagePath);
			showImageObject[objNum].enabled = isSetActive;
			if (masterJson.Master[nowPageId].positionNum2 != 0)
			{
				int objNum2 = masterJson.Master[nowPageId].positionNum2 - 1;
				showImageObject[objNum2].texture = (Texture2D)Resources.Load(masterJson.Master[nowPageId].imagePath2);
				showImageObject[objNum2].enabled = isSetActive;
			}
			if (masterJson.Master[nowPageId].positionNum3 != 0)
			{
				int objNum3 = masterJson.Master[nowPageId].positionNum3 - 1;
				showImageObject[objNum3].texture = (Texture2D)Resources.Load(masterJson.Master[nowPageId].imagePath3);
				showImageObject[objNum3].enabled = isSetActive;
			}
		}
		else
		{
			allSetActiveFalse();
		}
	}

	void allSetActiveFalse()
	{
		for (int i = 0; i < showImageObject.Length; i++)
		{
			showImageObject[i].enabled = false;
		}
	}
}
