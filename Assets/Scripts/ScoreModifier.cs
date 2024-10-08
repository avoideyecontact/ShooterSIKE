using UnityEngine;

// Изменение очков у указанного объекта
public class ScoreModifier : MonoBehaviour
{
    [SerializeField] private int deltaScore;

    // Изменение очков у указанного объекта
    public void Apply(GameObject targer)
    {
        var scoreComponent = targer.GetComponent<Score>();
        if (scoreComponent != null)
        {
            scoreComponent.ModifyScore(deltaScore);
        }
    }
}
