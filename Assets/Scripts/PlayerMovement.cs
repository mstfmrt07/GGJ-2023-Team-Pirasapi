using System;
using System.Collections;
using UnityEngine;

namespace Pirasapi
{

public class PlayerMovement : MonoBehaviour
{
    [Header("References")]
    public Player player;
    public CharacterAnimator animator;
    public Rigidbody2D rb2D;
    public Transform groundCheck;
    public ParticleSystem splashParticle;
    
    [Header("Movement & Jump")]
    public float movementSpeed;
    public float jumpForce;
    public float checkRadius;
    public LayerMask whatIsGround;
    public float onAirGravityFactor;
    public float groundGravityFactor;

    private float xInput;
    private bool facingRight = true;
    private bool isGrounded;
    private bool isJumping = false;

    private void Update()
    {
        if (!player.IsDead)
        {

            //Input and Animations
            xInput = InputController.Instance.MovementInput;
            if (xInput != 0)
            {
                animator.StartMove();
            }
            else
            {
                animator.StopMove();
            }

            if ((facingRight && xInput < 0) || (!facingRight && xInput > 0))
            {
                Flip();
            }

            if (InputController.Instance.JumpPressed)
            {
                if (isGrounded)
                {
                    Jump();
                }
            }

            if (InputController.Instance.JumpReleased && rb2D.velocity.y > 0f && !isGrounded)
            {
                rb2D.velocity = new Vector2(rb2D.velocity.x, rb2D.velocity.y * 0.5f);
            }
        }
    }
    private void FixedUpdate()
    {
        if (!player.IsDead)
        {
            Move();
        }

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        
        //Character has just landed
        if (isGrounded && rb2D.velocity.y < 0f)
        {
            animator.Fall();
            splashParticle.Play();
        }
    }

    void Flip()
    {
        var scale = player.transform.localScale;
        scale.x *= -1;
        player.transform.localScale = scale;

        facingRight = !facingRight;
    }

    void Jump()
    {
        isJumping = true;
        rb2D.velocity = new Vector2(rb2D.velocity.x, jumpForce);
        animator.Jump();
    }

    void Move()
    {
        rb2D.velocity = new Vector2(xInput * movementSpeed, rb2D.velocity.y);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheck.position, checkRadius);
    }
}
}