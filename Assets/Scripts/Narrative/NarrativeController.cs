using UnityEngine;

namespace Pirasapi
{
    public class NarrativeController : MonoSingleton<NarrativeController>
    {
        public MonologueUI monologueUI;
        
        public void ShowMonologue(Monologue monologue)
        {
            monologueUI.SetMonologoue(monologue);
        }
    }
}