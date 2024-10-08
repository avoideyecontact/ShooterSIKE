using UnityEngine;
using UnityEngine.SceneManagement;

// Перезапуск игры
public class RetryGame : MonoBehaviour
{
    [SerializeField] private string sceneName;

    // Перезапуск игры
    public void Retry()
    {
        SceneManager.LoadScene(sceneName);
    }
}
