using UnityEngine;
using UnityEngine.Events;

// Очки персонажа
public class Score : MonoBehaviour
{
    // Очки персонажа
    public int score;

    [SerializeField] private UnityEvent onScoreMinus;
    [SerializeField] private UnityEvent onScorePlus;
    [SerializeField] private UnityEvent onChange;

    // Изменение очков персонажа
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
