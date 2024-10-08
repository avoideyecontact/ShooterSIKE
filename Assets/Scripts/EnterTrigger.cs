using System;
using UnityEngine;
using UnityEngine.Events;

// Класс который запускает событие при заходе в триггер
public class EnterTrigger : MonoBehaviour
{
    [SerializeField] private new string tag;
    [SerializeField] private EnterEvent action;

    private void OnTriggerEnter(Collider other)
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
