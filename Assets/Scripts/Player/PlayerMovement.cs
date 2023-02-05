using System;
using System.Collections;
using UnityEngine;

namespace Pirasapi
{

public class PlayerMovement : Activatable
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

    protected override void Tick()
    {
        if (player.IsDead)
            return;
        
        xInput = InputController.Instance.MovementInput;
        if (xInput != 0)
        {
            animator.StartMove();
        }
        else
        {
            animator.StopMove();
        }

        Move();

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        
        //Character has just landed
        if (isGrounded && rb2D.velocity.y < 0f && isJumping)
        {
            LandOnGround();
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

    private void LandOnGround()
    {
        isJumping = false;
        animator.Fall();
        splashParticle.Play();
        SoundManager.Instance.PlaySound(SoundManager.Instance.landing);
    }

    void Flip()
    {
        var scale = player.graphics.transform.localScale;
        scale.x *= -1;
        player.graphics.transform.localScale = scale;

        facingRight = !facingRight;
    }

    void Jump()
    {
        isJumping = true;
        rb2D.velocity = new Vector2(rb2D.velocity.x, jumpForce);
        SoundManager.Instance.PlaySound(SoundManager.Instance.jumping);
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