using UnityEngine;
using UnityEngine.SceneManagement;

// ���������� ����
public class RetryGame : MonoBehaviour
{
    [SerializeField] private string sceneName;

    // ���������� ����
    public void Retry()
    {
        SceneManager.LoadScene(sceneName);
    }
}
