using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class PauseHandler : MonoBehaviour
{
    public KeyCode pauseKey;
    public bool Paused { get; private set; } = false;

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

    public void Pause()
    {
        Time.timeScale = 0f;
        Paused = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        canvasObj.SetActive(true);
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        Paused = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        canvasObj.SetActive(false);
        EventSystem.current.SetSelectedGameObject(null, null);
    }
}
