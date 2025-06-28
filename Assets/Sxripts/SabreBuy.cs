using UnityEngine;

public class SabreBuy : MonoBehaviour
{
    public int price = 5;
        void Start()
    {
        Debug.Log("Sabre Buy script started.");
    }

    public void OnClick()
    {
        if (SigmaMovement.coinsUsable < price)
        {
            Debug.Log("Not enough coins to buy a devil's sabre.");
        }
        else if (Blade.type == "blade" || Blade.type == "sabre" || Blade.type == "sucker")
        {
            Debug.Log("You already have a weapon.");
        }
        else if (Blade.type == "none" && SigmaMovement.coinsUsable >= price)
        {
            Debug.Log("Sabre purchased successfully.");
            SigmaMovement.coinsUsable -= price;
            Blade.type = "sabre";
        }
        
    }
}
