using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    // Чувствительность мыши по X
    public float sensX;
    // Чувствительность мыши по Y
    public float sensY;
    // Куда смотрит игрок
    public Transform playerOrientation;
    // Блокировка взгляда персонажа
    public bool locked = false;

    private float xRotation;
    private float yRotation;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        if (locked)
            return;

        float mouseX = Input.GetAxisRaw("Mouse X") * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * sensY;

        yRotation += mouseX;
        xRotation -= mouseY;

        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        playerOrientation.rotation = Quaternion.Euler(0, yRotation, 0);
    }

    // Установка чувствительности игры
    public void SetSensetivity(float sens)
    {
        sensX = sens;
        sensY = sens;
    }

    // Переключение блокировки взгляда
    public void ToggleLock()
    {
        locked = !locked;
    }
}
