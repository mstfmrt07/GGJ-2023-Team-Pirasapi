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

        public void Jump()
        {
            animator.ResetTrigger("Landed");
            animator.SetTrigger("Jump");
        }
        public void Fall()
        {
            animator.SetTrigger("Landed");
        }
    }
}