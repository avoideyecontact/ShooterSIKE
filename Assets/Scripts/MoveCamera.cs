using UnityEngine;

// Класс, который двигает позицию камеры за игровым объектом
public class MoveCamera : MonoBehaviour
{
    // Позиция камеры
    public Transform cameraPosition;

    void Update()
    {
        transform.position = cameraPosition.position;
    }
}
