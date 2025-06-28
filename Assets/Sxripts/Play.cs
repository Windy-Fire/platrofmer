using UnityEngine;
using UnityEngine.SceneManagement;
public class Play : MonoBehaviour
{
    public void OnClick()
    {
        SceneManager.LoadScene(1);
    }
}
