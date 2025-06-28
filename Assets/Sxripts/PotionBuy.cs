using UnityEngine;

public class PotionBuy : MonoBehaviour
{
    private int price = 5;
    private HPSlider hpController;
    void Start()
    {
        Debug.Log("Potion Buy script started.");
    }
    public void OnClick()
    {
        Debug.Log("Clicked, no error");
        if (SigmaMovement.coinsUsable < price)
        {
            Debug.Log("Not enough coins to buy a health pot.");
        }
        else if (SigmaMovement.health >= 4)
        {
            Debug.Log("Health is already full.");
        }
        else if (SigmaMovement.coinsUsable >= price && SigmaMovement.health < 4)
        {
            SigmaMovement.health = 4;
            SigmaMovement.coinsUsable -= price;
            hpController = Object.FindObjectOfType<HPSlider>();
            if (hpController != null)
            {
                hpController.UpdateHealthBar(SigmaMovement.health);
            }
            else
            {
                Debug.LogWarning("HPSlider not found in scene!");
            }
        }
        else
        {
            Debug.Log("Error");
        }
    }
}
