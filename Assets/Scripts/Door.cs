using UnityEngine;

// Дверь с которой необходимо взаимодействовать
public class Door : MonoBehaviour, IInteractable
{
    // Скорость открытия двери
    public float speed;
    [SerializeField] private float doorRotation;
    [SerializeField] private bool open;
    [SerializeField] private Transform edgePivotPoint;

    private float localAngle = 0;

    private void Start()
    {
        if (open)
        {
            Open();
            localAngle = doorRotation;
            transform.RotateAround(edgePivotPoint.position, Vector3.up, doorRotation);
        }
    }

    private void FixedUpdate()
    {
        if (open && localAngle < doorRotation)
        {
            transform.RotateAround(edgePivotPoint.position, Vector3.up, speed);
            localAngle += speed;
        }
        if (!open && localAngle > 0)
        {
            transform.RotateAround(edgePivotPoint.position, Vector3.up, -speed);
            localAngle -= speed;
        }
    }

    // Метод открытия двери
    public void Open()
    {
        open = true;
    }

    // Метод закрытия двери
    public void Close()
    {
        open = false;
    }

    // Метод взаимодействия с дверью
    public void Interact()
    {
        if (open)
        {
            Close();
        }
        else
        {
            Open();
        }
    }
}
