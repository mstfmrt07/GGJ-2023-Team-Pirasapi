using System.Collections.Generic;
using UnityEngine;

namespace Pirasapi
{
    public class LevelManager : MonoSingleton<LevelManager>
    {
        public Transform levelContainer;
        public List<Level> levels;

        private Level currentLevel = null;

        private int CurrentLevelIndex => CurrentLevelNumber % levels.Count;
        public int CurrentLevelNumber
        {
            get => SaveManager.Instance.CurrentLevel;
            set => SaveManager.Instance.CurrentLevel = value;
        }

        public Level CurrentLevel => currentLevel;

        private void Start()
        {
            LoadCurrentLevel();
        }

        public void LoadLevel(int levelNumber)
        {
            CurrentLevelNumber = levelNumber;

            if (currentLevel != null)
            {
                ResetCurrentLevel();
            }

            currentLevel = Instantiate(levels[CurrentLevelIndex], levelContainer);
            GameEvents.OnLevelLoad?.Invoke();
        }

        public void LoadCurrentLevel()
        {
            LoadLevel(CurrentLevelNumber);
        }

        public void LoadNextLevel()
        {
            LoadLevel(CurrentLevelNumber + 1);
        }

        private void ResetCurrentLevel()
        {
            currentLevel.Dispose();
            RecycleBin.Instance.DisposeAll();
        }
    }
}
