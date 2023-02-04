using UnityEngine;

namespace Pirasapi
{
    public class CharacterAnimator : MonoBehaviour
    {
        public Animator animator;

        public void Move()
        {
            animator.SetBool("Move", true);
        }
        
        public void StopMove()
        {
            animator.SetBool("Move", false);
        }

        public void Jump()
        {
            
        }
    }
}