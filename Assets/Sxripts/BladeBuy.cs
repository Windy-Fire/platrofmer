using UnityEngine;

public class BladeBuy : MonoBehaviour
{
    public int price = 1;
        void Start()
    {
        Debug.Log("Blade Buy script started.");
    }

    public void OnClick()
    {
        if (SigmaMovement.coinsUsable < price)
        {
            Debug.Log("Not enough coins to buy a blade.");
        }
        else if (Blade.type == "blade" || Blade.type == "sabre" || Blade.type == "sucker")
        {
            Debug.Log("You already have a weapon.");
        }
        else if (Blade.type == "none" && SigmaMovement.coinsUsable >= price)
        {
            Debug.Log("Blade purchased successfully.");
            SigmaMovement.coinsUsable -= price;
            Blade.type = "blade";
        }
        
    }
}
