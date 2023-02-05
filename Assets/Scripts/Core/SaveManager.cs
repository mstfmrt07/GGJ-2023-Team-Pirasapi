using UnityEngine;

namespace Pirasapi
{
    public class SaveManager : MonoSingleton<SaveManager>
    {
        public int CurrentLevel
        {
            get => PlayerPrefs.GetInt("CurrentLevel", 0);
            set => PlayerPrefs.SetInt("CurrentLevel", value);
        }
        
        public bool SoundOn
        {
            get => PlayerPrefs.GetInt("SoundOn", 1) == 1;
            set => PlayerPrefs.SetInt("SoundOn", value ? 1 : 0);
        }
    }
}
