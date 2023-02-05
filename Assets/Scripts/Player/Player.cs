using System;
using UnityEngine;

namespace Pirasapi
{
    public class Player : MonoSingleton<Player>, IGameEventsHandler
    {
        public PlayerMovement movement;
        public GameObject graphics;
        
        private bool isDead;
        public bool IsDead => isDead;

        private void Awake()
        {
            SubscribeGameEvents();
        }

        public void SubscribeGameEvents()
        {
            GameEvents.OnLevelLoad += OnLevelLoad;
            GameEvents.OnLevelStarted += OnLevelStarted;
            GameEvents.OnLevelCompleted += OnLevelCompleted;
            GameEvents.OnLevelFailed += OnLevelFailed;
            
            GameEvents.OnGamePaused += OnGamePaused;
            GameEvents.OnGameResumed += OnGameResumed;
        }

        public void OnLevelLoad()
        {
            movement.IsActive = false;
        }

        public void OnLevelStarted()
        {
            movement.IsActive = true;
        }

        public void OnLevelCompleted()
        {
            movement.IsActive = false;
        }

        public void OnLevelFailed()
        {
            movement.IsActive = false;
        }

        public void OnGamePaused()
        {
            movement.IsActive = false;
        }

        public void OnGameResumed()
        {
            movement.IsActive = true;
        }
    }
}