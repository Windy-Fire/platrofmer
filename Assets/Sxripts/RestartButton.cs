using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class RestartButton : MonoBehaviour
{
    public void OnClick()
    {
        SceneManager.LoadScene(1);
    }
}
