using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIHealthController : MonoBehaviour
{
    private Slider Coin;
    void Awake()
    {
        Coin = GameObject.Find("Slider").GetComponent<Slider>();
    }
    public void SetUpCoinBar(int startValue)
    {
        Coin.maxValue = 10;
        Coin.value = startValue;
    }
    public void UpdateCoinBar(int value)
    {
        Coin.value = value;
    }
}
