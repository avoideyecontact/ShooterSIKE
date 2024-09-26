using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject weapon;
    [SerializeField] private Transform gunPosition;

    private bool armed = false;

    private void Start()
    {
        if (weapon != null)
        {
            ArmPlayer(weapon);
        }
    }

    public void ArmPlayer(GameObject weapon)
    {
        Instantiate(weapon, gunPosition);
        armed = true;
    }
}
