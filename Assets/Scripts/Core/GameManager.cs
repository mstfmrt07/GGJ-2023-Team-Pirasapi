using UnityEngine;

namespace Pirasapi
{
    public class GameManager : MonoSingleton<GameManager>, IResettable
    {
        private int score;
        private bool isGameStarted = false;

        public bool GameStarted => isGameStarted;
        public int Score { get => score; set => score = value; }

        private void Awake()
        {
            ApplyReset();
        }

        public void StartGame()
        {
            if (isGameStarted)
                return;

            isGameStarted = true;
            LevelManager.Instance.CurrentLevel.PlayIntro();
            GameEvents.OnLevelStarted?.Invoke();
        }

        public void FinishGame(bool winCondition)
        {
            if (!isGameStarted)
                return;

            isGameStarted = false;

            if (winCondition)
            {
                GameEvents.OnLevelCompleted?.Invoke();
            }
            else
            {
                GameEvents.OnLevelFailed?.Invoke();
            }
        }

        public void ApplyReset()
        {
            isGameStarted = false;
            score = 0;

        }

        public void PauseGame()
        {
            //TODO: Implement pause game
            GameEvents.OnGamePaused?.Invoke();
        }

        public void ResumeGame()
        {
            //TODO: Implement resume game
            GameEvents.OnGameResumed?.Invoke();
        }
    }
}
