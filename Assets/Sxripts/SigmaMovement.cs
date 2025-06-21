using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
public class SigmaMovement : MonoBehaviour
{
    private float movementSpeed = 0.2f;
    private float jumpSpeed = 6f;
    private Rigidbody2D rb;
    private bool movingLeft = false, movingRight = false;
    private SliderCoin slider;
    private SliderKey sliderKey;
    public int coins;
    public int keys;
    public int maxCoin;
    public int maxKey;
    private bool coinsReady = false;
    private bool keysReady = false;
    public int sceneNumber = 1;
    private bool isGrounded;
    private int health = 3;
    private HPSlider hpController;
    private Animator anim;
    private SpriteRenderer sprite;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        slider = Object.FindObjectOfType<SliderCoin>();
        sliderKey = Object.FindObjectOfType<SliderKey>();
        hpController = Object.FindObjectOfType<HPSlider>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        hpController.SetUpHealthBar(health);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            movingLeft = true;
            anim.SetBool("isWalking", true);
            sprite.flipX = true;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            movingRight = true;
            anim.SetBool("isWalking", true);
            sprite.flipX = false;
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            movingLeft = false;
            anim.SetBool("isWalking", false);
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            movingRight = false;
            anim.SetBool("isWalking", false);
        }
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
        }
        if (coins == maxCoin)
        {
            coinsReady = true;
        }
        if (keys == maxKey)
        {
            keysReady = true;
        }
        if (keysReady == true && coinsReady == true)
        {
            SceneManager.LoadScene(sceneNumber);
            coinsReady = false;
            keysReady = false;
        }
        if(isGrounded == false)
        {
            anim.SetBool("isJumping", true);
        }
        else if(isGrounded == true)
        {
            anim.SetBool("isJumping", false);
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
            if (slider != null)
            {
                slider.UpdateCoinBar(1);
                Destroy(collision.gameObject);
            }
            coins += 1;
        }
        else if (collision.gameObject.CompareTag("Key"))
        {
            if (sliderKey != null)
            {
                sliderKey.UpdateKeyBar(1);
                Destroy(collision.gameObject);
            }
            keys += 1;
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            health = health - 1;
            if (hpController != null)
            {
                hpController.UpdateHealthBar(health);
            }
            if (health == 0)
            {
                SceneManager.LoadScene(0);
            }
        }
        else if (collision.gameObject.CompareTag("Respawn"))
        {
            SceneManager.LoadScene(0);
        }
        }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}