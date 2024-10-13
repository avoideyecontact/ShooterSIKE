using UnityEngine;

// Класс игрока для отслеживания взаимодействия с оружием и интеракцией с объектами
public class Player : Creature
{
    [SerializeField] private GameObject weapon;
    [SerializeField] private Transform weaponPosition;
    [SerializeField] private Transform cameraTransform;

    // Вооружен игрок или нет
    public bool armed { get; private set; }
    private Gun gun;
    private RaycastInteraction raycast;

    private void Start()
    {
        raycast = GetComponent<RaycastInteraction>();

        if (weapon != null)
        {
            ArmPlayer(weapon);
        }
    }

    void Update()
    {
        if (Input.GetAxis("Fire") > 0 && gun != null)
        {
            gun.Use(creatureName);
        }


        if (Input.GetButtonUp("Interaction"))
        {
            raycast.Raycast();
        }

    }

    // Вооружить игрока
    public void ArmPlayer(GameObject weapon)
    {
        weapon = Instantiate(weapon, weaponPosition);
        gun = weapon.GetComponent<Gun>();
        armed = true;
    }
}
