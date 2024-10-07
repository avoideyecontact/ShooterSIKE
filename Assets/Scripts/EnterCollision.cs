using System;
using UnityEngine;
using UnityEngine.Events;

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

    [Serializable]
    public class EnterEvent : UnityEvent<GameObject>
    {

    }
}
