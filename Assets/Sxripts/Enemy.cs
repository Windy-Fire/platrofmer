using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    public int hp = 5;
    public static int damage = 1;
    public Transform startPoint, endPoint;
    public bool reverse;
    private SpriteRenderer spriteRenderer;
    public HPSlider hpController;
    private Animator anim;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }
    void FixedUpdate()
    {
        if (transform.position.x < endPoint.position.x && reverse == false)
        {
            MoveRight();
        }
        else if (transform.position.x > startPoint.position.x && reverse == true)
        {
            MoveLeft();
        }

    }
    void MoveRight()
    {
        transform.Translate(0.05f, 0, 0);
        if (transform.position.x >= endPoint.position.x)
        {
            reverse = true;
        }
    }
    void MoveLeft()
    {
        transform.Translate(-0.05f, 0, 0);
        if (transform.position.x <= startPoint.position.x)
        {
            reverse = false;
        }
    }
    void Update()
    {
        if (reverse == true)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("RightHand"))
        {
            if (Blade.type == "blade")
            {
                anim.SetBool("TakesDamage", true);
                hp -= 1;
                if (hp <= 0)
                {
                    Destroy(this.gameObject);
                }
                return;
            }
            else if (Blade.type == "sabre")
            {
                anim.SetBool("TakesDamage", true);
                Destroy(this.gameObject);
                return;
            }
            else if (Blade.type == "sucker")
            {
                hp -= 2;
                anim.SetBool("TakesDamage", true);
                if (SigmaMovement.health < 4)
                {
                    SigmaMovement.health = SigmaMovement.health + 1;
                    hpController.UpdateHealthBar(SigmaMovement.health);
                }
                if (hp <= 0)
                {
                    Destroy(this.gameObject);
                }
            }
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("RightHand"))
        {
            anim.SetBool("TakesDamage", false);
        }
    }
}