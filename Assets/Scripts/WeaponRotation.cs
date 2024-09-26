using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRotation : MonoBehaviour
{
    [SerializeField] private Transform cameraTransform;

    private void Update()
    {
        transform.rotation = cameraTransform.rotation;
    }
}
