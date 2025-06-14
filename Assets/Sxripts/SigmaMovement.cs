using UnityEngine;
public class SigmaMovement : MonoBehaviour
{    
    public float movementSpeed = 5f;
    // [SerializeField] public int coinCount = 0;
    public float jumpSpeed = 500f;
    private Rigidbody2D rb;
    private bool movingLeft, movingRight = false;
    private SliderCoin slider;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        slider = FindObjectOfType<SliderCoin>();
        // if (slider != null)
        // {
        //     slider.SetUpCoin(coinCount);
        // }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            movingLeft = true;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            movingRight = true;
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            movingLeft = false;
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            movingRight = false;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
        }
    }

    void FixedUpdate()
    {
        if (movingLeft)
        {
            rb.AddForce(Vector2.left * movementSpeed, ForceMode2D.Impulse);
        }
        if (movingRight)
        {
            rb.AddForce(Vector2.right * movementSpeed, ForceMode2D.Impulse);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            // coinCount += 1;
            if (slider != null)
                slider.UpdateCoinBar(1);
            Destroy(collision.gameObject);
        }
    }
}