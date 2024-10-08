using System;
using UnityEngine;
using UnityEngine.Events;

// Класс который запускает событие при коллизии
public class EnterCollision : MonoBehaviour
{
    [SerializeField] private new string tag;
    [SerializeField] private EnterEvent action;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag(tag))
        {
            action?.Invoke(other.gameObject);
        }
    }

    // Расширение unity event (без него нельзя было бы вызвать делегат у другого объекта)
    [Serializable]
    public class EnterEvent : UnityEvent<GameObject>
    {

    }
}
