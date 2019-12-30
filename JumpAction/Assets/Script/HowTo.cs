using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HowTo : MonoBehaviour
{

	//　読み込んだテキストを出力するUIテキスト
	public Text dataText;
	//　読む込むテキストが書き込まれている.txtファイル
	[SerializeField]
	private TextAsset textAsset;
	//　Resourcesフォルダから直接テキストを読み込む
	private string loadText2;
	//　改行で分割して配列に入れる
	private string[] splitText2;
	//　現在表示中テキスト2番号
	private int textNum2;

	public Text count;
	int NextCount=1;

	void Start()
	{
		loadText2 = (Resources.Load("HowTo", typeof(TextAsset)) as TextAsset).text;
		splitText2 = loadText2.Split(char.Parse("\n"));
		textNum2 = 0;
		dataText.text = splitText2[textNum2];
		textNum2++;
	}

	void Update()
	{
		count.text = "(" + NextCount + "/" + splitText2.Length + ")";
	}


	public void onClickAct()
	{

		//　Resourcesフォルダに配置したテキストファイルの内容を表示
		NextCount++;
		NextCount %= splitText2.Length + 1;
		if(NextCount == 0)
		{
			NextCount = 1;
		}

		if (splitText2[textNum2] != "")
		{
			dataText.text = splitText2[textNum2];
			textNum2++;
			if (textNum2 >= splitText2.Length)
			{
				textNum2 = 0;
			}
		}
		else
		{
			dataText.text = "";
			textNum2++;
		}

	}


}
