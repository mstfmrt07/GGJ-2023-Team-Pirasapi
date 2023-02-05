using UnityEngine;

namespace Pirasapi
{
    public abstract class SaveManager : MonoSingleton<SaveManager>
    {
        public int CurrentLevel
        {
            get => PlayerPrefs.GetInt("CurrentLevel", 0);
            set => PlayerPrefs.SetInt("CurrentLevel", value);
        }

        public bool TutorialFinished
        {
            get => PlayerPrefs.GetInt("TutorialFinished", 0) != 0;
            set => PlayerPrefs.SetInt("TutorialFinished", value ? 1 : 0);
        }
    }
}
