using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

// Класс отвечающий за паузу в игре
public class PauseHandler : MonoBehaviour
{
    // Кнопка на которую переключается пауза
    public KeyCode pauseKey;

    // Игра на паузе или нет
    public bool Paused { get; private set; }

    [SerializeField] private GameObject canvasObj;
    [SerializeField] private UnityEvent _action;

    void Start()
    {
        canvasObj = transform.Find("Canvas").gameObject;
        canvasObj.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(pauseKey))
            SwitchPause();
    }

    // Переключение паузы
    public void SwitchPause()
    {
        if (Paused)
        {
            Resume();
        }
        else
        {
            Pause();
        }

        _action?.Invoke();
    }

    // Поставить игру на паузу
    public void Pause()
    {
        TimeStop();
        canvasObj.SetActive(true);
    }

    // Снять игру с паузы
    public void Resume()
    {
        TimeResume();
        canvasObj.SetActive(false);
    }

    // Остановка времени игры
    public void TimeStop()
    {
        Time.timeScale = 0f;
        Paused = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    // Возобновить течение времени игры
    public void TimeResume()
    {
        Time.timeScale = 1f;
        Paused = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        EventSystem.current.SetSelectedGameObject(null, null);
    }
}
