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
    public int sceneNumber;
    public bool isGrounded;
    public static int health = 4;
    public HPSlider hpController;
    public SliderShield shieldController;
    private Animator anim;
    private SpriteRenderer sprite;
    public static int coinsUsable;
    private static SigmaMovement instance;
    public static int shieldAmount = 0;
    public string charmType = "none";
    public Text charmText;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        slider = Object.FindObjectOfType<SliderCoin>();
        sliderKey = Object.FindObjectOfType<SliderKey>();
        hpController = Object.FindObjectOfType<HPSlider>();
        shieldController = Object.FindObjectOfType<SliderShield>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        hpController.SetUpHealthBar(health);
        shieldController.SetUpShieldBar(shieldAmount);
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
        if (coins >= maxCoin)
        {
            coinsReady = true;
        }
        if (keys >= maxKey)
        {
            keysReady = true;
        }
        if (keysReady == true && coinsReady == true)
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentSceneIndex + 1);
            coinsReady = false;
            keysReady = false;
        }
        if (isGrounded == false)
        {
            anim.SetBool("isJumping", true);
        }
        else if (isGrounded == true)
        {
            anim.SetBool("isJumping", false);
        }
        if (charmType == "haste")
        {
            movementSpeed = 0.4f;
        }
        else if (charmType == "jump")
        {
            jumpSpeed = 12f;
        }
        else
        {
            movementSpeed = 0.2f;
            jumpSpeed = 6f;
        }
        if (charmText != null)
        {
            charmText.text = ("Current charm: " + charmType);
        }
    }

    void FixedUpdate()
    {
        Debug.Log(health);
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
            coinsUsable += 1;
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
        else if (collision.gameObject.CompareTag("Secret"))
        {
            Destroy(collision.gameObject);
            SceneManager.LoadScene(3);
            return;
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
            anim.SetBool("IsHurt", true);
            if (shieldAmount > 0)
            {
                shieldAmount -= ObstacleMovement.damage;
                if (shieldController != null)
                {
                    shieldController.UpdateShieldBar(shieldAmount);
                }
            }
            else if (hpController != null)
            {
                health -= ObstacleMovement.damage;
                hpController.UpdateHealthBar(health);
            }
            if (health <= 0)
            {
                SceneManager.LoadScene(1);
                coins = 0;
                keys = 0;
                transform.position = new Vector2(-3.4f, 1.8f);
                sceneNumber = 1;
            }
        }
        else if (collision.gameObject.CompareTag("Respawn"))
        {
            SceneManager.LoadScene(1);
            coins = 0;
            keys = 0;
            transform.position = new Vector2(-3.4f, 1.8f);
            sceneNumber = 0;
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            anim.SetBool("IsHurt", false);
        }
    }
    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        hpController.UpdateHealthBar(0);
        shieldController.UpdateShieldBar(0);
        sceneNumber = scene.buildIndex;
        coins = 0;
        keys = 0;
        charmType = "none";
        coinsReady = false;
        keysReady = false;
        isGrounded = true;
        FindSceneReferences();
        if (sceneNumber == 0)
        {
            Destroy(gameObject);
            return;
        }
        else
        if (sceneNumber == 1)
        {
            transform.position = new Vector2(-3.4f, 1.8f);
            maxCoin = 10;
            maxKey = 3;
            health = 4;
            shieldAmount = 0;
            coinsUsable = 0;
            coinsReady = false;
            keysReady = false;
            charmType = "none";
            coins = 0;
            keys = 0;
        }
        else if (sceneNumber == 2)
        {
            transform.position = new Vector2(-14, 5);
            maxCoin = 25;
            maxKey = 10;
            shieldAmount = 0;
        }
        else if (sceneNumber == 3)
        {
            transform.position = new Vector2(230.5f, -18f);
            maxCoin = 16;
            maxKey = 6;
            shieldAmount = 0;
        }
        else if (sceneNumber == 4)
        {
            Destroy(gameObject);
            return;
        }
        if (hpController != null)
        {
            hpController.UpdateHealthBar(health);
        }
        void FindSceneReferences()
        {
            slider = Object.FindObjectOfType<SliderCoin>();
            sliderKey = Object.FindObjectOfType<SliderKey>();
            hpController = Object.FindObjectOfType<HPSlider>();
            shieldController = Object.FindObjectOfType<SliderShield>();
        }
    }
}