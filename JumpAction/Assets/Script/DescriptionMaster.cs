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
	public int imageNum;
	public int imageNum2;
	public int imageNum3;
}

public class DescriptionMaster : MonoBehaviour
{
	// 読み込んだテキストを出力するUIテキスト
	public Text dataText;

	// ページ番号を表示させるUIテキスト
	public Text countText;

	// 表示させる画像オブジェクト格納用
	public GameObject[] showImageObject;

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
	}

	void Update()
	{
		int showPageId = (nowPageId == 0) ? 1 : (nowPageId + 1);
		countText.text = "(" + showPageId + "/" + masterJson.Length + ")";
		if (masterJson.Master[nowPageId].isImage)
		{
			setActiveImage(true);
		}
	}

	public void OnPressNextButton()
	{
		if (masterJson.Master[nowPageId].isImage)
		{
			setActiveImage(false);
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
			setActiveImage(false);
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

	// 99999 をnullとして扱う
	void setActiveImage(bool isSetActive)
	{
		showImageObject[masterJson.Master[nowPageId].imageNum].SetActive(isSetActive);
		if (masterJson.Master[nowPageId].imageNum2 != 99999)
		{
			showImageObject[masterJson.Master[nowPageId].imageNum2].SetActive(isSetActive);
		}
		if (masterJson.Master[nowPageId].imageNum3 != 99999)
		{
			showImageObject[masterJson.Master[nowPageId].imageNum3].SetActive(isSetActive);
		}
	}
}
