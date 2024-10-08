using UnityEngine;

// ��������� ����� � ���������� �������
public class ScoreModifier : MonoBehaviour
{
    [SerializeField] private int deltaScore;

    // ��������� ����� � ���������� �������
    public void Apply(GameObject targer)
    {
        var scoreComponent = targer.GetComponent<Score>();
        if (scoreComponent != null)
        {
            scoreComponent.ModifyScore(deltaScore);
        }
    }
}
