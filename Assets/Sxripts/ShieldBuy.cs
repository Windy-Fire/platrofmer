using UnityEngine;
public class ShieldBuy : MonoBehaviour
{
    private int price = 4;
    private SliderShield shieldController;
    void Start()
    {
        Debug.Log("Shield Buy script started.");
        shieldController = Object.FindObjectOfType<SliderShield>();    
    }
public void OnClick()
{
    Debug.Log("Clicked, no error");
    if (SigmaMovement.coinsUsable < price)
    {
        Debug.Log("Not enough coins to buy a shield.");
    }
    else if (SigmaMovement.shieldAmount >= 1)
    {
        Debug.Log("Protection bar is already full or not used up completely.");
    }
    else if (SigmaMovement.coinsUsable >= price && SigmaMovement.shieldAmount == 0)
    {
        SigmaMovement.shieldAmount = Mathf.Min(SigmaMovement.shieldAmount + 2, 2);
        SigmaMovement.coinsUsable -= price;
        
        if (shieldController != null)
        {
            shieldController.UpdateShieldBar(SigmaMovement.shieldAmount);
        }
        else
        {
            Debug.LogWarning("ShieldSlider not found in scene!");
        }
    }
    else
    {
        Debug.Log("Error");
    }
}
}