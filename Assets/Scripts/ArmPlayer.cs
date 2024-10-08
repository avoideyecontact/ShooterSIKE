using UnityEngine;

//  ласс, позвол€ющий объектам вооружить игрока (например дл€ сферы с оружием)
public class ArmPlayer : MonoBehaviour
{
    [SerializeField] private GameObject weapon;

    // ‘ункци€, котора€ вооружает игрока
    public void Arm(GameObject targer)
    {
        var player = targer.GetComponent<Player>();
        if (!player.armed)
        {
            player.ArmPlayer(weapon);
        }
    }
}
