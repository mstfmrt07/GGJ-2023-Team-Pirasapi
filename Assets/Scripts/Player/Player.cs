using System;
using DG.Tweening;
using UnityEngine;

namespace Pirasapi
{
    public class Player : MonoSingleton<Player>, IGameEventsHandler
    {
        public Transform mainBody;
        public PlayerMovement movement;
        public GameObject graphics;
        public float initialSize;
        
        private bool isDead;
        public bool IsDead => isDead;

        private float size;
        public float Size => size;

        private Vector3 playerSize;

        private void Awake()
        {
            SubscribeGameEvents();
            playerSize = mainBody.localScale;
            size = initialSize;
        }

        public void CollectDrop(CollectableDrop drop)
        {
            GameManager.Instance.Score++;
            size += drop.size;
            playerSize = Vector3.one * (size / initialSize);
            mainBody.DOScale(playerSize, 0.25f).SetEase(Ease.OutBack);
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