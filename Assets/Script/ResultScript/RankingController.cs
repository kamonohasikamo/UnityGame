using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PlayFab;
using PlayFab.ClientModels;

//==================================================
// ランキング機能の処理
// 5位まで表示させる場合、配列を6(= 5 + 1)個分で用意する。
// 一旦いままでの5個のスコアと現在のスコア(計6個の値)を保存する。
// // その後、ソートを行う。
// ソート後、上から順にみていき
// 上位5個を保存し、6個目を破棄。
// (→ 今回のスコアだろうが、今までのスコアだろうが、最下位が消される仕様)
// この保存するときに、現在のスコアと一致していれば、赤色にする。
// ただし、現在のスコアと同一の値をとった場合
// このままだと両方赤色になってしまうので
// Flagを用意して、1回だけ赤色にする、という処理を行えばOK
//==================================================
public class RankingController : MonoBehaviour
{
	// UI Text
	public Text rankingText;
	string playerName;

	// sort用配列
	private int[] sort = new int[5];
	private int tmp = 0;
	public bool isFirst;

	void Start()
	{
		GameManager.instance.Banner.Hide();
		isFirst = false;
		WorldOrMyScore.WorldOrMyScoreNum = 0;
		playerName = PlayerPrefs.GetString("Name");
		rankingText.text = "";
		setUserName(playerName);
		sendScore();
		saveRanking();
		showRanking();
	}

	public void OnPressWorldButton()
	{
		rankingText.text = "";
		if (WorldOrMyScore.WorldOrMyScoreNum % 2 == 0)
		{
			this.gameObject.GetComponentInChildren<Text>().text = "MyScore";
			rankingText.fontSize = 60;
			getRanking();
		}
		else
		{
			this.gameObject.GetComponentInChildren<Text>().text = "World";
			rankingText.fontSize = 80;
			showRanking();
		}
		WorldOrMyScore.addChangeNum();
	}

	void saveRanking()
	{
		// Scoreを端末に保存する
		// 第一引数：保存名
		// 第二引数：保存する値(SetIntなのでInt型限定)
		PlayerPrefs.SetInt("4", GameManager.instance.Score);
		PlayerPrefs.Save();
	}

	void showRanking()
	{
		rankingText.text += "Ranking\n";
		if (!isFirst)
		{
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
		}

		bool showNowScoreFlag = true;
		for (int i = 0; i < 4; i++)
		{
			// 今のスコアがソート配列の中のものと一致したら、表示させる処理
			if (showNowScoreFlag && GameManager.instance.Score == sort[i])
			{
				rankingText.text += "<color=red>" + (i + 1) + ":" + sort[i].ToString("D5") + "</color>\n";
				if (!isFirst)
				{
					PlayerPrefs.SetInt("" + i, sort[i]);
				}
				showNowScoreFlag = false;
			}
			else
			{
				rankingText.text += (i + 1) + ":" + sort[i].ToString("D5") + "\n";
				if (!isFirst)
				{
					PlayerPrefs.SetInt("" + i, sort[i]);
				}
			}
		}
		if (!isFirst)
		{
			PlayerPrefs.Save();
			isFirst = true;
		}
	}

	private void getRanking()
	{
		var request = new GetLeaderboardRequest
		{
			StatisticName = Define.RANKING_NAME,
			StartPosition = 0, // 何位以降のランキングを取得するか指定
			MaxResultsCount = 5, // 最大件数
		};
		PlayFabClientAPI.GetLeaderboard(request, showRanking, OnError);
	}

	void showRanking(GetLeaderboardResult result)
	{
		rankingText.text += "Ranking\n";
		foreach (var item in result.Leaderboard)
		{
			rankingText.text += $"{item.Position + 1}位: {item.DisplayName} - {item.StatValue}\n";
		}
	}

	private void sendScore()
	{
		if (GameManager.instance.getIsCheat())
		{
			return;
		}
		var data = new StatisticUpdate
		{
			StatisticName = Define.RANKING_NAME,
			Value = GameManager.instance.Score,
		};

		var request = new UpdatePlayerStatisticsRequest
		{
			Statistics = new List<StatisticUpdate>
			{
				data
			}
		};

		PlayFabClientAPI.UpdatePlayerStatistics(request, OnSuccess, OnError);

		void OnSuccess(UpdatePlayerStatisticsResult result)
		{

		}
	}
	private void setUserName(string userName)
	{
		var request = new UpdateUserTitleDisplayNameRequest
		{
			DisplayName = userName
		};

		PlayFabClientAPI.UpdateUserTitleDisplayName(request, OnSuccess, OnError);
	}

	void OnSuccess(UpdateUserTitleDisplayNameResult result)
	{

	}

	void OnError(PlayFabError error)
	{

	}
}
