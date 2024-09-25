using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthModifier : MonoBehaviour
{
    [SerializeField] private int deltaHealth;

    public void Apply(GameObject targer)
    {
        var healthComponent = targer.GetComponent<Health>();
        if (healthComponent != null)
        {
            healthComponent.ModifyHealth(deltaHealth);
        }
    }
}
