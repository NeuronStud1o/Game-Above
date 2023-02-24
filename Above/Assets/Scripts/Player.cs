using System.Collections;
using System.Collections.Generic;
using UnityEngine;




enum Direction
{
    Right,
    Left
}



public class Player : MonoBehaviour
{
    private Direction direction;
    [SerializeField] private float speed = 5f;
    public GameObject Panel;

    public float jumpForce = 7f;
    Rigidbody2D rb;

    AudioSource jumpSound;

    void Start()
    {
        direction = Direction.Right;

        rb = GetComponent<Rigidbody2D>();

        jumpSound = GetComponent<AudioSource>();
    }

    void Update()
    {

        switch (direction)
        {
            case Direction.Left:
                transform.localScale = new Vector3(-1.3f, 1.3f, 0f);
                transform.position += Vector3.left * speed * Time.deltaTime;
                break;
            case Direction.Right:
                transform.localScale = new Vector3(1.3f, 1.3f, 0f);
                transform.position += Vector3.right * speed * Time.deltaTime;
                break;
        }

        rb.velocity = new Vector2(0, rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            rb.velocity = new Vector2(0, jumpForce);
            jumpSound.Play();
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("RightWall"))
        {
            direction = Direction.Left;

        }
        if (collision.collider.CompareTag("LeftWall"))
        {
            direction = Direction.Right;
        }

        if (collision.collider.CompareTag("Enemy"))
        {
            GetComponent<Player>().enabled = false;

            Panel.SetActive(true);

        }
    }

}
