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
    private bool popped;
    ParticleSystem popParticle;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        popParticle = GetComponentsInChildren<ParticleSystem>()[4];
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.Instance.GetIsPaused())
        {
            horizontal = Input.GetAxisRaw("Horizontal");

            animator.SetFloat("horizontal", horizontal);
            animator.SetBool("jumping", jumping);
            animator.SetBool("popped", popped);

            if (horizontal < 0)
            {
                sr.flipX = true;
            }
            else if (horizontal > 0)
            {
                sr.flipX = false;
            }

            if (Input.GetKeyDown("space") && !jumping)
            {
                body.AddForce(new Vector2(0, jumpForce));
                jumping = true;
            }
            else if (Input.GetKeyDown("space") && jumping && !popped)
            {
                popped = true;

                body.AddForce(new Vector2(0, jumpForce));
                popParticle.Play();

            }
        }
    }


    private void FixedUpdate()
    {
        if (!GameManager.Instance.GetIsPaused())
        {
            body.velocity = new Vector2(horizontal * runSpeed, body.velocity.y);
        }
        else
        {
            body.velocity = new Vector2(0,0);
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        jumping = false;
    }

}
