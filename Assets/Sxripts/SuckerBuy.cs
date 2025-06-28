using UnityEngine;

public class SuckerBuy : MonoBehaviour
{
    public int price = 4;
    void Start()
    {
        Debug.Log("Sword Buy script started.");
    }

    public void OnClick()
    {
        if (SigmaMovement.coinsUsable < price)
        {
            Debug.Log("Not enough coins to buy a sword of a bloodsucker.");
        }
        else if (Blade.type == "blade" || Blade.type == "sabre" || Blade.type == "sucker")
        {
            Debug.Log("You already have a weapon.");
        }
        else if (Blade.type == "none" && SigmaMovement.coinsUsable >= price)
        {
            Debug.Log("Sword purchased successfully.");
            SigmaMovement.coinsUsable -= price;
            Blade.type = "sucker";
            Debug.Log("Blade.type: " + Blade.type);
        }
        
    }
}
