using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//==================================================
// ランキング機能の処理
// 5位まで表示させる場合、配列を6(= 5 + 1)個分で用意する。
// 一旦いままでの5個のスコアと現在のスコア(計6個の値)を保存する。
// // その後、ソートを行う。
// ソート後、上から順にみていき
// 上位5個を保存し、6個目を破棄。
// (→　今回のスコアだろうが、今までのスコアだろうが、最下位が消される仕様)
// この保存するときに、現在のスコアと一致していれば、赤色にする。
// ただし、現在のスコアと同一の値をとった場合
// このままだと両方赤色になってしまうので
// Flagを用意して、1回だけ赤色にする、という処理を行えばOK
//==================================================
public class RankingController : MonoBehaviour
{
	// UI Text
	private Text targetText;

	// sort用配列
	private int[] sort = new int[5];
	private int tmp = 0;

	void Start()
	{
		this.targetText = this.GetComponent<Text>();
		 // 初期化
		this.targetText.text = "";
		saveRanking();
		showRanking();
	}

	void saveRanking()
	{
		// Scoreを端末に保存する
		// 第一引数：保存名
		// 第二引数：保存する値(SetIntなのでInt型限定)
		PlayerPrefs.SetInt("4", GameManager.instance.getScore());
		PlayerPrefs.Save();
	}

	void showRanking()
	{
		this.targetText.text += "Ranking\n";
		for (int i = 0; i < 5; i++)
		{
			sort[i] = PlayerPrefs.GetInt("" + i, 0);
		}

		// sort配列の中身を降順ソートする
		for (int start = 1; start < sort.Length; start++)
		{
			for (int end = sort.Length - 1; end >= start; end--)
			{
				if (sort[end - 1] <= sort[end])
				{
					tmp = sort[end - 1];
					sort[end - 1] = sort[end];
					sort[end] = tmp;
				}
			}
		}

		bool showNowScoreFlag = true;
		for (int i = 0; i < 4; i++)
		{
			// 今のスコアがソート配列の中のものと一致したら、表示させる処理
			if (showNowScoreFlag && GameManager.instance.getScore() == sort[i])
			{
				this.targetText.text += "<color=red>" + (i + 1) + ":" + sort[i].ToString("D5") + "</color>\n";
				PlayerPrefs.SetInt("" + i, sort[i]);
				showNowScoreFlag = false;
			}
			else
			{
				this.targetText.text += (i + 1) + ":" + sort[i].ToString("D5") + "\n";
				PlayerPrefs.SetInt("" + i, sort[i]);
			}
		}
		PlayerPrefs.Save();
	}
}
