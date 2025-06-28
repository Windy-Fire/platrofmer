using UnityEngine;
using System.Collections;
public class Blade : MonoBehaviour
{
    public static string type;
    private SigmaMovement sigmaMovement;
    private ObstacleMovement enemy;
    void Start()
    {
        sigmaMovement = GetComponent<SigmaMovement>();
        type = "none";
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (type == "blade")
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                StartCoroutine(ResetBladeType());
            }
        }
        else if (type == "sabre")
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                Destroy(other.gameObject);
                type = "none";
            }
            
        }
        else if (type == "sucker")
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                StartCoroutine(ResetBladeType());
            }
        }
    }
    private IEnumerator ResetBladeType()
    {
        yield return null;
        type = "none";
    }
    void OnSceneLoaded()
    {
        type = "none";
    }
}