using UnityEngine;
using UnityEngine.UI;

public class HP : MonoBehaviour
{
    public Slider hpSlider;

    public void SetMaxHP(int maxHP)
    {
        if (hpSlider == null) hpSlider = GetComponent<Slider>();
        hpSlider.maxValue = maxHP;
        hpSlider.value = maxHP;
    }

    public void SetHP(int hp)
    {
        if (hpSlider == null) hpSlider = GetComponent<Slider>();
        hpSlider.value = hp;
    }
}