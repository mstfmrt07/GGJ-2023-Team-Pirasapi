using System;
using UnityEngine;

namespace Pirasapi
{
    public class PlayerMovement : MonoBehaviour
    {
        public Player mainBody;
        public Rigidbody2D rb2D;
        [SerializeField]private Collider2D groundCheckCollider;
        [SerializeField] private LayerMask groundLayer;
        
        [SerializeField] private float movementSpeed;
        [SerializeField] private float jumpForce;

        private bool facingRight;
        private bool isGrounded;

        private void Awake()
        {
            facingRight = true;
            isGrounded = false;
        }

        private void FixedUpdate()
        {
            Move();
            Jump();
        }


        public void Move()
        {
            var input = InputController.Instance.MovementInput;
            if (input == 0f)
                return;

            var wantsToTurnRight = (input > 0f && !facingRight);
            var wantsToTurnLeft = (input < 0f && facingRight);
            if (wantsToTurnLeft || wantsToTurnRight)
            {
                InvertX();
            }

            rb2D.velocity = (facingRight ? Vector2.right : Vector2.left) * movementSpeed;
        }

        public void InvertX()
        {
            var scale = mainBody.graphics.transform.localScale;
            scale.x *= -1;
            mainBody.graphics.transform.localScale = scale;

            facingRight = !facingRight;
        }

        public void Jump()
        {
            var input = InputController.Instance.JumpInput;
            isGrounded = GroundCheck();
            if (!input || !isGrounded)
                return;
            rb2D.AddForce(Vector2.up * jumpForce);
        }


        public bool GroundCheck()
        {
            RaycastHit2D hit = Physics2D.Raycast(groundCheckCollider.bounds.center, Vector2.down,
                groundCheckCollider.bounds.extents.y + 0.01f, groundLayer);
            return hit.collider != null;
        }
        
    }
}