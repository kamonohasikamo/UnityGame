using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonChangeEnabled : MonoBehaviour
{
    //==========================================
    // GameSceneでタップ連打した際の
    // タップ判定が残る挙動の対応用クラス
    //==========================================
    
    #pragma warning disable 649
	[SerializeField]
	private GameObject tweetButton;
    [SerializeField]
	private GameObject againButton;
    [SerializeField]
	private GameObject toTitleButton;
	#pragma warning restore 649

    void Awake()
    {
        tweetButton.GetComponent<Button>().enabled = false;
        againButton.GetComponent<Button>().enabled = false;
        toTitleButton.GetComponent<Button>().enabled = false;
    }

    void Start()
    {
        tweetButton.GetComponent<Button>().enabled = true;
        againButton.GetComponent<Button>().enabled = true;
        toTitleButton.GetComponent<Button>().enabled = true;
    }
}
