using UnityEngine;

public class ShopButton : MonoBehaviour
{
    private GameObject shop;
    void OnClick()
    {
        gameObject.SetActive(shop);
    }
}