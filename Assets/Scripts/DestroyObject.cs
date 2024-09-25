using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    [SerializeField] private GameObject objectToDestroy;

    public void Destroy()
    {
        Destroy(objectToDestroy);
    }
}
