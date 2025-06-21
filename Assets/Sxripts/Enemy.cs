using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    private int HP;
    private int Damage;
    public Transform startPoint, endPoint;
    public bool reverse;
    private SpriteRenderer spriteRenderer;
    void Start()
    {
    spriteRenderer = GetComponent<SpriteRenderer>();
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
}