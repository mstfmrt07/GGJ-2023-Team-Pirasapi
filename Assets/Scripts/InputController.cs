using UnityEngine;

namespace Pirasapi
{
    public class InputController : MonoSingleton<InputController>
    {
        public float MovementInput => Input.GetAxis("Horizontal");
        public bool JumpInput => Input.GetKey(KeyCode.Space);
    }
}