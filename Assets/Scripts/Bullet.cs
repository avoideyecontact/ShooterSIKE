using System;
using UnityEngine;
using UnityEngine.Events;

// ����� ���� ������� �������� ��������
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

    // ���������� unity event (��� ���� ������ ���� �� ������� ������� � ������� �������)
    [Serializable]
    public class HitEvent : UnityEvent<GameObject>
    {

    }
}
