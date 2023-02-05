using UnityEngine;

namespace Pirasapi
{
    public class SoundManager : MonoSingleton<SoundManager>, IGameEventsHandler
    {
        [Header("References")]
        public AudioClip bgMusic;
        public AudioClip buttonClick;
        public AudioClip success;
        public AudioClip fail;
        public AudioClip jumping;
        public AudioClip landing;
        public AudioClip typeWriter;


        private AudioSource bgSource;

        private void Awake()
        {
            SubscribeGameEvents();
            bgSource = PlaySound(bgMusic, true);
            bgSource.volume = 0.5f;
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

        public AudioSource PlaySound(AudioClip clip, bool looping = false, float lifeTime = -1f)
        {
            if (!SaveManager.Instance.SoundOn)
                return null;

            GameObject soundGameObject = new GameObject(clip.name);
            AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
            audioSource.clip = clip;
            audioSource.playOnAwake = false;

            if (looping)
            {
                audioSource.loop = true;
                audioSource.Play();

                if (lifeTime > 0f)
                {
                    Destroy(soundGameObject, lifeTime);
                }
            }
            else
            {
                audioSource.PlayOneShot(clip);
                Destroy(soundGameObject, clip.length);
            }

            return audioSource;
        }

        public void OnLevelLoad()
        {
        }

        public void OnLevelStarted()
        {
        }

        public void OnLevelCompleted()
        {
        }

        public void OnLevelFailed()
        {
            SoundManager.Instance.PlaySound(SoundManager.Instance.fail);
        }

        public void OnGamePaused()
        {
        }

        public void OnGameResumed()
        {
        }

        public void OnLevelSucceeded()
        {
            SoundManager.Instance.PlaySound(SoundManager.Instance.success);
        }
    }
}
