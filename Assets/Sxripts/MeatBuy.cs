using UnityEngine;

public class MeatBuy : MonoBehaviour
{
    private int price = 2;
    private HPSlider hpController;
    void Start()
    {
        Debug.Log("Meat Buy script started.");
    }
    public void OnClick()
    {
        Debug.Log("Clicked, no error");
        if (SigmaMovement.coinsUsable < price)
        {
            Debug.Log("Not enough coins to buy meat.");
        }
        else if (SigmaMovement.health >= 4)
        {
            Debug.Log("Health is already full.");
        }
        else if (SigmaMovement.coinsUsable >= price && SigmaMovement.health < 4)
        {
            SigmaMovement.health = Mathf.Min(SigmaMovement.health + 1, 4);
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