using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmPlayer : MonoBehaviour
{
    [SerializeField] private GameObject weapon;

    public void Arm(GameObject targer)
    {
        var player = targer.GetComponent<Player>();
        if (!player.armed)
        {
            player.ArmPlayer(weapon);
        }
    }
}
