using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//UI使うときは忘れずに。
using UnityEngine.UI;

public class HpController : MonoBehaviour
{
    //最大HPと現在のHP。
    int maxHp = 100;
    float currentHp;

    public float NaturalDamege = 0.01f;
    //Sliderを入れる
    public Slider slider;

    void Start()
    {
        //Sliderを満タンにする。
        slider.value = 1;
        //現在のHPを最大HPと同じに。
        currentHp = maxHp;
    }

    void Update()
    {
        currentHp = currentHp - NaturalDamege;
        slider.value = (float)currentHp / (float)maxHp;
    }

}