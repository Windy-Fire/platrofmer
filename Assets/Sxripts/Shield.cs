using UnityEngine;
using UnityEngine.UI;

public class Shield : MonoBehaviour
{
    public Slider defSlider;

    public void SetMaxDef(int maxDef)
    {
        if (defSlider == null) defSlider = GetComponent<Slider>();
        defSlider.maxValue = maxDef = 2;
    }

    public void SetDef(int shieldAmount)
    {
        if (defSlider == null) defSlider = GetComponent<Slider>();
        defSlider.value = shieldAmount;
    }
}