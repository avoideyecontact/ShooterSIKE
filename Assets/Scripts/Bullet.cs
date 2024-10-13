using System;
using UnityEngine;
using UnityEngine.Events;

// Класс пули которой стреляет пистолет
public class Bullet : MonoBehaviour
{
    public string owner;
    [SerializeField] private HitEvent action;

    private void OnCollisionEnter(Collision other)
    {
        Creature creature = other.gameObject.GetComponent<Creature>();

        if (creature != null)
        {
            if (owner != creature.creatureName)
            {
                action?.Invoke(other.gameObject);
            }
        }
    }

    // Расширение unity event (без него нельзя было бы вызвать делегат у другого объекта)
    [Serializable]
    public class HitEvent : UnityEvent<GameObject>
    {

    }
}
