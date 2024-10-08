using UnityEngine;

// Выход из игры
public class QuitGame : MonoBehaviour
{
    // Кнопка выхода из игры
    public KeyCode quitKey;

    void Update()
    {
        if (Input.GetKeyDown(quitKey))
            Quit();
    }

    // Функция выхода из игры (в зависимости от того где запущена игра)
    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
                Application.Quit();
#endif
    }
}
