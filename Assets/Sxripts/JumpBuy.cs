using UnityEngine;

public class JumpBuy : MonoBehaviour
{
    public int price = 5;
    private SigmaMovement sigmaMovement;
    void Start()
    {
        sigmaMovement = Object.FindObjectOfType<SigmaMovement>();
        Debug.Log("Jump Buy script started.");
    }

    public void OnClick()
    {
        if (SigmaMovement.coinsUsable < price)
        {
            Debug.Log("Not enough coins to buy a jump amulet.");
        }
        else if (sigmaMovement.charmType == "haste" || sigmaMovement.charmType == "jump")
        {
            Debug.Log("You already have an amulet.");
        }
        else if (sigmaMovement.charmType == "none" && SigmaMovement.coinsUsable >= price)
        {
            Debug.Log("Jump amulet purchased successfully.");
            SigmaMovement.coinsUsable -= price;
            sigmaMovement.charmType = "jump";
        }
        else
        {
            Debug.Log("Unknown error occurred while trying to purchase the jump amulet.");
        }
    }
}