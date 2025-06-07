using UnityEngine;

public class Cion : MonoBehaviour
{
    public GameObject that;
    void Start()
    {
        
    }
    void OnTriggerEnter2D()
    {
        Destroy(that);
    }
}