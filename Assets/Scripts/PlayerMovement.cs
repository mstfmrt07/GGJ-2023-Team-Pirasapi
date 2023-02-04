using System;
using UnityEngine;

namespace Pirasapi
{
    public class PlayerMovement : MonoBehaviour
    {
        public Player mainBody;
        public Rigidbody2D rb2D;
        
        [SerializeField] private float movementSpeed;
        [SerializeField] private float jumpForce;

        private bool facingRight;
        private bool isJumping;

        private void Awake()
        {
            facingRight = true;
            isJumping = false;
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
            rb2D.AddForce(Vector2.up * jumpForce);
        }
    }
}