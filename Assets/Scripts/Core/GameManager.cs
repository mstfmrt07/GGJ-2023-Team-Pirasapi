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
            InputController.Instance.tapToStart.OnTap -= StartGame;
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

            InputController.Instance.tapToStart.OnTap += StartGame;
        }

        public void PauseGame()
        {
            //TODO: Implement pause game
        }

        public void ResumeGame()
        {
            //TODO: Implement resume game
        }
    }
}
