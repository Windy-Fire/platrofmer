using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SliderKey : MonoBehaviour
{
    private Slider keySlider;
    public int keyCount = 0;
    public int maxKeys = 3;

    void Awake()
    {
        keySlider = GetComponent<Slider>();
        SetUpKeyBar(keyCount, maxKeys);
    }
    public void SetUpKeyBar(int startValue, int maxValue = 10)
    {
        keySlider.maxValue = maxValue;
        keySlider.value = startValue;
    }

    public void UpdateKeyBar(int value)
    {
        keyCount += value;
        keySlider.value = keyCount;
    }
}