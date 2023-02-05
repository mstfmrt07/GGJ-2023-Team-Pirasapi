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
    }
}
