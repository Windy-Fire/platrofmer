using UnityEngine;
public class SigmaMovement : MonoBehaviour
{    
    public float movementSpeed = 3f;
    public int coinCount = 0;
    public float jumpSpeed = 500f;
    private Rigidbody2D rb;
    private bool movingLeft, movingRight = false;

     void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Coin.SetUpHealthBar(health);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            movingLeft = true;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            movingRight = true;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
        }
    }
    void FixedUpdate()
    {
        if(movingLeft == true)
        {
            rb.AddForce(Vector2.left * movementSpeed, ForceMode2D.Impulse);
            movingLeft = false;
        }
        if(movingRight == true)
        {
            rb.AddForce(Vector2.right * movementSpeed, ForceMode2D.Impulse);
            movingRight = false;
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            coinCount = coinCount + 1;
        }
    }
}