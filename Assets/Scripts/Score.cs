using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Score : MonoBehaviour
{
    public int score;

    [SerializeField] private UnityEvent onScoreMinus;
    [SerializeField] private UnityEvent onScorePlus;
    [SerializeField] private UnityEvent onChange;

    public void ModifyScore(int deltaScore)
    {
        score += deltaScore;
        onChange?.Invoke();

        if (deltaScore < 0)
        {
            onScoreMinus?.Invoke();
        }

        if (deltaScore > 0)
        {
            onScorePlus.Invoke();
        }
    }
}
