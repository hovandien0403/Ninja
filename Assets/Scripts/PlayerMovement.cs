using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    private Animator anim;

    [SerializeField] private LayerMask jumpableGround;

    private float dirX = 0f;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;

    [SerializeField] private AudioSource moveSoundEffect;
    private enum MovementState { idle, running, jumping, falling, doubleJump}
    public bool doubleJump;

    [SerializeField] private AudioSource jumpSoundEffect;
    // Start is called before the first frame update
    private void Start()
    {
      rb = GetComponent<Rigidbody2D>();
      coll = GetComponent<BoxCollider2D>();
      sprite = GetComponent<SpriteRenderer>(); 
      anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        /*if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            jumpSoundEffect.Play();
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, 0);
        }*/
        if (Input.GetButtonDown("Jump"))
        {
            if (IsGrounded())
            {
                jumpSoundEffect.Play();
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                doubleJump = true;
            }
            else if(doubleJump && SceneManager.GetActiveScene().buildIndex > 1)
            {
                 jumpSoundEffect.Play();
                 rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                 doubleJump = false;
            }

          

            
        }


        UpdateAnimationState();


    }

    private void UpdateAnimationState()
    {
        MovementState state;
        if (dirX > 0f)
        {
            state = MovementState.running;
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            state = MovementState.running;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }

        if (rb.velocity.y > .1f)
        {
            
            state = MovementState.jumping;
            if (!doubleJump)
            {
                state = MovementState.doubleJump;
            }
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }

      

        anim.SetInteger("state", (int)state);
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }

    private void moveSound()
    {
        moveSoundEffect.Play();
    }

}
    