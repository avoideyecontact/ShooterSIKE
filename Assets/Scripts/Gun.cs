using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float fireRate;
    public float firePower;
    public bool fireAllowed;
    public float bulletLifespan = 5;

    public GameObject bulletPrefab;

    [SerializeField] private Transform gunBarrelPosition;

    public void Fire()
    {
        if (fireAllowed)
        {
            var bullet = Instantiate(bulletPrefab, gunBarrelPosition.position, transform.parent.rotation);
            bullet.GetComponent<Rigidbody>();
            bullet.GetComponent<Rigidbody>().AddForce(transform.forward * firePower, ForceMode.Impulse);
            Destroy(bullet, bulletLifespan);

            fireAllowed = false;
            StartCoroutine(FireCooldown());
        }
    }

    IEnumerator FireCooldown()
    {
        yield return new WaitForSeconds(fireRate);
        fireAllowed = true;
    }
}
