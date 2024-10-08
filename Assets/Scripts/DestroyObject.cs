using UnityEngine;

// Класс для удаления объектов со сцены
public class DestroyObject : MonoBehaviour
{
    [SerializeField] private GameObject objectToDestroy;

    // Функция для удаления объекта со сцены
    public void Destroy()
    {
        Destroy(objectToDestroy);
    }
}
