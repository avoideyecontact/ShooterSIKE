using System.Collections;
using UnityEngine;

// Класс описывающий стреляющий пистолет
public class Gun : MonoBehaviour, Weapon
{
    // Темп стрельбы
    public float fireRate;
    // Сила выстрела
    public float firePower;
    // Разрешен выстрел или нет
    public bool fireAllowed;
    // Время жизни пули
    public float bulletLifespan = 5;

    // Префаб пули
    public GameObject bulletPrefab;

    [SerializeField] private Transform gunBarrelPosition;

    // Использовать оружие (произвести выстрел)
    public void Use(string owner)
    {
        if (fireAllowed)
        {
            var bullet = Instantiate(bulletPrefab, gunBarrelPosition.position, transform.parent.rotation);
            bullet.GetComponent<Bullet>().owner = owner;
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
