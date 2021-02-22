using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    // There is currently a bug when jumping through a platform
    // The player can spam space to "super jump" while going through platform
    // Possibly input a timer to not allow quick succession jumps

    Rigidbody2D body;
    SpriteRenderer sr;
    Animator animator;

    float horizontal;
    public float runSpeed = 5f;
    public float jumpForce = 10f;

    private bool jumping;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        animator.SetFloat("horizontal", horizontal);

        if (horizontal < 0)
        {
            sr.flipX = true;
        } else if (horizontal > 0)
        {
            sr.flipX = false;
        }

        if (Input.GetKeyDown("space") && !jumping)
        {
            body.AddForce(new Vector2(0, jumpForce));
            jumping = true;
        }
    }


    private void FixedUpdate()
    {
        body.velocity = new Vector2(horizontal * runSpeed, body.velocity.y);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        jumping = false;
    }

}
