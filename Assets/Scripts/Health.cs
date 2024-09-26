using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public int health;

    [SerializeField] private UnityEvent onDamage;
    [SerializeField] private UnityEvent onHeal;
    [SerializeField] private UnityEvent onDie;
    [SerializeField] private UnityEvent onChange;

    public void ModifyHealth(int deltaHealth)
    {
        health += deltaHealth;
        onChange?.Invoke();

        if (deltaHealth < 0)
        {
            onDamage?.Invoke();
        }

        if (deltaHealth > 0)
        {
            onHeal.Invoke();
        }

        if (health <= 0)
        {
            onDie?.Invoke();
        }
    }
}
