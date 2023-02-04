using UnityEngine;

namespace Pirasapi
{
    public class CharacterAnimator : MonoBehaviour
    {
        public Animator animator;

        public void StartMove()
        {
            animator.SetBool("IsRunning", true);
        }
        
        public void StopMove()
        {
            animator.SetBool("IsRunning", false);
        }

        public bool IsGrounded
        {
            get => animator.GetBool("IsGrounded");
            set => animator.SetBool("IsGrounded", value);
        }
        
        public void Jump()
        {
            animator.SetTrigger("Jump");
        }
    }
}