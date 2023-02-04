using UnityEngine;

namespace Pirasapi
{
    public class InputController : MonoSingleton<InputController>
    {
        public float MovementInput => Input.GetAxis("Horizontal");
        public bool JumpPressed => Input.GetButtonDown("Jump");
        public bool JumpReleased => Input.GetButtonUp("Jump");
    }
}