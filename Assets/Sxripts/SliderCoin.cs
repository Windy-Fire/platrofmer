using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SliderCoin : MonoBehaviour
{
    private Slider coinSlider;
    public int coinCount = 0;
    public int maxCoins = 10;

    void Awake()
    {
        coinSlider = GetComponent<Slider>();
        SetUpCoinBar(coinCount, maxCoins);
    }

    public void SetUpCoinBar(int startValue, int maxValue = 10)
    {
        coinSlider.maxValue = maxValue;
        coinSlider.value = startValue;
    }

    public void UpdateCoinBar(int value)
    {
        coinCount += value;
        coinSlider.value = coinCount;
    }
 void Update()
    {
        if(coinCount == maxCoins)
        {
            SceneManager.LoadScene(1);
        }
    }
}