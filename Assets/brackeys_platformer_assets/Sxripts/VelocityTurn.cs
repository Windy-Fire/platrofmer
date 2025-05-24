using UnityEngine;

public class VelocityTurn : MonoBehaviour
{
    private float currentSpeed;
    private float speed = 4f;
    private Rigidbody2D rb2d;
    private SpriteRenderer sprite;
    private float jumpForce = 5f;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
    //  if(currentSpeed > 0f)
    //     {
    //         GetComponent<SpriteRenderer>().flipX = false;
    //     }
    //     else if(curentSpeed < 0f)
    //     {
    //         GetComponent<SpriteRenderer>().flipX = true;
    //     }   
    }
}
