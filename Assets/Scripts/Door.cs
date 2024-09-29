using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    [SerializeField] private bool open = false;
    [SerializeField] private Transform edgePivotPoint;

    private void Start()
    {
        if (open)
        {
            Open();
        }
    }

    public void Open()
    {
        open = true;
        transform.RotateAround(edgePivotPoint.position, Vector3.up, 90);
    }

    public void Close()
    {
        open = false;
        transform.RotateAround(edgePivotPoint.position, Vector3.down, 90);
    }

    public void Interact()
    {
        if (open)
        {
            Close();
        }
        else
        {
            Open();
        }
    }
}
