using UnityEngine;

namespace Pirasapi
{
    public class InputController : MonoSingleton<InputController>
    {
        public TapDetector tapToStart;
        public float MovementInput => Input.GetAxis("Horizontal");
        public bool JumpPressed => Input.GetButtonDown("Jump");
        public bool JumpReleased => Input.GetButtonUp("Jump");

        public bool SliceAbilityInput => Input.GetKeyDown(KeyCode.Q);
        
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
        }
        public void OnLevelLoad()
        {
            tapToStart.IsActive = true;
        }

        public void OnLevelStarted()
        {
            tapToStart.IsActive = false;
        }

        public void OnLevelCompleted()
        {
        }

        public void OnLevelFailed()
        {
        }
    }
}