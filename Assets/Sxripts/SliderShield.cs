using UnityEngine;
using UnityEngine.UI;
public class SliderShield : MonoBehaviour
{
    public int startShield = 0;
    public Slider defenceBar;
    void Awake()
    {
        defenceBar = GameObject.Find("ShieldSlider").GetComponent<Slider>();
    }
    public void SetUpShieldBar(int shieldAmount)
    {
        if (defenceBar != null)
        {
            defenceBar.maxValue = 2;
            defenceBar.value = shieldAmount;
        } 
    }
    public void UpdateShieldBar(int value)
    {
        if (defenceBar != null)
        {
            defenceBar.value = value;
        }
    }
}
