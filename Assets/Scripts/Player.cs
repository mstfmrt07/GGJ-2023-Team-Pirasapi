using UnityEngine;

namespace Pirasapi
{
    public class Player : MonoSingleton<Player>
    {
        public PlayerMovement movement;
        public GameObject graphics;

        public void Jump()
        {
            movement.Jump();
        }
    }
}