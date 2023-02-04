using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pirasapi
{
    public class MonologueTrigger : MonoBehaviour
    {
        public Monologue monologue;

        public void TriggerMonologue()
        {
            NarrativeController.Instance.ShowMonologue(monologue);
        }
    }
}
