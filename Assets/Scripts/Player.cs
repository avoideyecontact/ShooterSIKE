using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject weapon;
    [SerializeField] private Transform weaponPosition;

    private bool armed = false;
    private Gun gun;

    private void Start()
    {
        if (weapon != null)
        {
            ArmPlayer(weapon);
        }
    }

    void Update()
    {
        if (Input.GetAxis("Fire") > 0 && gun != null)
        {
            gun.Fire();
        }
    }

    public void ArmPlayer(GameObject weapon)
    {
        weapon = Instantiate(weapon, weaponPosition);
        gun = weapon.GetComponent<Gun>();
        armed = true;
    }
}
