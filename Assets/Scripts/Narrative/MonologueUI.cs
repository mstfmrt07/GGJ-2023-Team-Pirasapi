using System;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Pirasapi
{
    public class MonologueUI : MonoBehaviour
    {
        public CanvasGroup canvasGroup;
        public Image monologoueImage;
        public TMP_Text monologueText;
        public TMP_Text monologueTitle;
        public Transform progressParent;
        public Image progressDotPrefab;
        public Color currentDotColor;
        public Color defaultDotColor;

        public Action OnMonologueEnded;
        
        private Monologue monologue;
        private int currentSpeechIndex;

        private void Awake()
        {
            canvasGroup.alpha = 0f;
            canvasGroup.interactable = false;
        }

        public void SetMonologoue(Monologue monologue)
        {
            if (this.monologue == null || this.monologue.nextMonologue == null || monologue != this.monologue.nextMonologue)
            {
                canvasGroup.alpha = 0f;
                canvasGroup.DOFade(1f, 1f).SetEase(Ease.InBack);
                canvasGroup.interactable = true;
            }
            
            this.monologue = monologue;
            currentSpeechIndex = -1;
            
            ClearProgressParent();
            for (int i = 0; i < monologue.speeches.Count; i++)
            {
                var progressDot = Instantiate(progressDotPrefab, progressParent);
            }
            
            this.Wait(0.8f, NextSpeech);
        }

        public void NextSpeech()
        {
            if (currentSpeechIndex < monologue.speeches.Count - 1)
            {
                currentSpeechIndex++;
                UpdateUI();
            }
            else
            {
                OnMonologueEnded?.Invoke();
            }
        }

        public void SkipMonologue()
        {
            canvasGroup.DOFade(0f, 1f).SetEase(Ease.OutBack).OnComplete(() => enabled = false);
            canvasGroup.interactable = false;
        }

        public void PreviousSpeech()
        {
            if (currentSpeechIndex > 0)
            {
                currentSpeechIndex--;
                UpdateUI();
            }
        }

        private void ClearProgressParent()
        {
            foreach (Transform dot in progressParent)
            {
                Destroy(dot.gameObject);
            }
        }

        private void UpdateUI()
        {
            monologoueImage.sprite = monologue.graphics;

            if (currentSpeechIndex == 0)
            {
                DoText(monologueTitle, monologue.name);
            }
            
            DoText(monologueText, monologue.speeches[currentSpeechIndex], delay: (currentSpeechIndex == 0)? 0.8f : 0.2f);
            
            for (int i = 0; i < progressParent.childCount; i++)
            {
                bool isCurrent = (i == currentSpeechIndex);
                
                progressParent.GetChild(i).GetComponent<Image>().color = isCurrent ? currentDotColor : defaultDotColor;
                progressParent.GetChild(i).localScale = isCurrent ? (Vector3.one * 1.12f) : Vector3.one;
            }
        }

        private void DoText(TMP_Text text, string content, float characterAppearDuration = 0.036f, float delay = 0.0f)
        {
            SoundManager.Instance.PlaySound(SoundManager.Instance.typeWriter, true,
                content.Length * characterAppearDuration * 1.5f);
            DOTween.Kill(text.GetInstanceID());
            text.text = "";
            text.DOText(content, content.Length * characterAppearDuration).SetDelay(delay).SetId(text.GetInstanceID());
        }
    }
}