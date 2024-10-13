using System.Collections;
using UnityEngine;

// ����� ����������� ���������� ��������
public class Gun : MonoBehaviour, Weapon
{
    // ���� ��������
    public float fireRate;
    // ���� ��������
    public float firePower;
    // �������� ������� ��� ���
    public bool fireAllowed;
    // ����� ����� ����
    public float bulletLifespan = 5;

    // ������ ����
    public GameObject bulletPrefab;

    [SerializeField] private Transform gunBarrelPosition;

    // ������������ ������ (���������� �������)
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
