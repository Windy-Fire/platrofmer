using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Shop : MonoBehaviour
{
    private bool isActive = false;
    public GameObject shopUI;
    public Text coinsText;
    void Update()
    {
        coinsText.text = SigmaMovement.coinsUsable.ToString();
        if (Input.GetKeyDown(KeyCode.I))
        {
            isActive = !isActive;
            shopUI.SetActive(isActive);
        }
    }
}