using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPSlider : MonoBehaviour
{
    public int startValue = 3;
    public Slider healthBar;

    void Awake()
    {
        healthBar = GameObject.Find("HPSlider").GetComponent<Slider>();
    }

    public void SetUpHealthBar(int health)
    {
        if (healthBar != null)
        {
            healthBar.maxValue = startValue;
            healthBar.value = health;
        }
    }

    public void UpdateHealthBar(int value)
    {
        if (healthBar != null)
        {
            healthBar.value = value;
        }
    }
}