using UnityEngine;

namespace Pirasapi
{
    public class Player : MonoSingleton<Player>
    {
        public PlayerMovement movement;
        public GameObject graphics;
        
        private bool isDead;
        public bool IsDead => isDead;

    }
}