using Pirasapi;
using UnityEngine;

public class Level : MonoBehaviour, IDisposable
{
    public Monologue intro;

    public void PlayIntro()
    {
        NarrativeController.Instance.ShowMonologue(intro);
    }
    
    public void Dispose()
    {
        Destroy(gameObject);
    }
}
