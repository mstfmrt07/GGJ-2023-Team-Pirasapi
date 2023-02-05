using System;
using Pirasapi;
using UnityEngine;

public class Level : MonoBehaviour, IDisposable
{
    public Monologue intro;

    public void PlayIntro()
    {
        if (intro == null)
            return;
        
        NarrativeController.Instance.ShowMonologue(intro);
    }
    
    public void Dispose()
    {
        Destroy(gameObject);
    }

    public void FinishLevel()
    {
        GameManager.Instance.FinishGame(true);
    }
}
