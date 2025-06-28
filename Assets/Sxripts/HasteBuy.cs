using UnityEngine;

public class HasteBuy : MonoBehaviour
{
    public int price = 5;
    private SigmaMovement sigmaMovement;
    void Start()
    {
        sigmaMovement = Object.FindObjectOfType<SigmaMovement>();
        Debug.Log("Haste Buy script started.");
    }

    public void OnClick()
    {
        if (SigmaMovement.coinsUsable < price)
        {
            Debug.Log("Not enough coins to buy a haste amulet.");
        }
        else if (sigmaMovement.charmType == "haste" || sigmaMovement.charmType == "jump")
        {
            Debug.Log("You already have an amulet.");
        }
        else if (sigmaMovement.charmType == "none" && SigmaMovement.coinsUsable >= price)
        {
            Debug.Log("Haste amulet purchased successfully.");
            SigmaMovement.coinsUsable -= price;
            sigmaMovement.charmType = "haste";
        }
        else
        {
            Debug.Log("Unknown error occurred while trying to purchase the haste amulet.");
        }
    }
}