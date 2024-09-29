using System;
using UnityEngine;
using UnityEngine.Events;

public class EnterCollision : MonoBehaviour
{
    [SerializeField] private string _tag;
    [SerializeField] private EnterEvent action;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag(_tag))
        {
            action?.Invoke(other.gameObject);
        }
    }

    [Serializable]
    public class EnterEvent : UnityEvent<GameObject>
    {

    }
}
