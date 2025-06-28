using UnityEngine;
using UnityEngine.UI;
public class WaeponImage : MonoBehaviour
{
    private Image sprite;
    private Blade bladeScript;
    [SerializeField] private Sprite defaultSprite;
    [SerializeField] private Sprite knifeSprite;
    [SerializeField] private Sprite sabreSprite;
    [SerializeField] private Sprite suckerSprite;
    void Start()
    {
        sprite = GetComponent<Image>();
    }
    void Update()
    {
        if (Blade.type == "none")
        {
            sprite.sprite = defaultSprite;
        }
        {
            bladeScript = FindObjectOfType<Blade>();
        }
        if (Blade.type == "blade")
        {
            sprite.sprite = knifeSprite;
        }
        else if (Blade.type == "sabre")
        {
            sprite.sprite = sabreSprite;
        }
        else if (Blade.type == "sucker")
        {
            sprite.sprite = suckerSprite;
        }
        else
        {
            sprite.sprite = null;
        }
    }
}
