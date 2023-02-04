using UnityEngine;

namespace Pirasapi
{
    public class NarrativeController : MonoSingleton<NarrativeController>
    {
        public MonologueUI monologueUI;

        private Monologue currentMonologue;
        
        public void ShowMonologue(Monologue monologue)
        {
            GameManager.Instance.PauseGame();
            currentMonologue = monologue;
            monologueUI.SetMonologoue(currentMonologue);

            monologueUI.OnMonologueEnded += HideMonologue;
        }

        public void HideMonologue()
        {
            if (currentMonologue.nextMonologue != null)
            {
                currentMonologue = currentMonologue.nextMonologue;
                monologueUI.SetMonologoue(currentMonologue);
            }
            else
            {
                GameManager.Instance.ResumeGame();
                currentMonologue = null;
                monologueUI.SkipMonologue();
                monologueUI.OnMonologueEnded -= HideMonologue;
            }
        }
    }
}