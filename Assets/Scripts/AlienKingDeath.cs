using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// ������ ��� �������� ������ ������� ����������
public class AlienKingDeath : MonoBehaviour
{
    private bool isDying;
    private bool isDead;
    private Health health;
    private Quaternion initialRotation;

    [SerializeField] private UnityEvent onDeath;

    // ����� ������� ����������
    public void Death()
    {
        isDying = true;

        if (health != null)
        {
            health.enabled = false;
        }
    }

    void Start()
    {
        health = GetComponent<Health>();
        
        initialRotation = transform.localRotation;
    }

    void Update()
    {
        if (isDying)
        {
            if (transform.rotation.z < 0.63f)
            {
                transform.localRotation *= Quaternion.Euler(0, 0, 30 * Time.deltaTime);
            }
            else
            {
                if (!isDead)
                {
                    onDeath?.Invoke();
                }
                isDead = true;
                isDying = false;
            }
        }
    }
}
