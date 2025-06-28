using UnityEngine;

public class InfoCloseButton : MonoBehaviour
{
    public InfoButton infoButton;
    public void OnClick()
    {
        infoButton.info.SetActive(false);
    }
}
