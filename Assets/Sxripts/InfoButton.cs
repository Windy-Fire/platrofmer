using UnityEngine;

public class InfoButton : MonoBehaviour
{
    public GameObject info;
    public bool isActive;
    public void OnClick()
    {
        info.SetActive(true);
        isActive = false;
    }
}