using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    public float speed;
    [SerializeField] private float doorRotation;
    [SerializeField] private bool open;
    [SerializeField] private Transform edgePivotPoint;

    private float localAngle = 0;

    private void Start()
    {
        if (open)
        {
            Open();
            localAngle = doorRotation;
            transform.RotateAround(edgePivotPoint.position, Vector3.up, doorRotation);
        }
    }

    private void FixedUpdate()
    {
        if (open && localAngle < doorRotation)
        {
            transform.RotateAround(edgePivotPoint.position, Vector3.up, speed);
            localAngle += speed;
        }
        if (!open && localAngle > 0)
        {
            transform.RotateAround(edgePivotPoint.position, Vector3.up, -speed);
            localAngle -= speed;
        }
    }

    public void Open()
    {
        open = true;
        //transform.RotateAround(edgePivotPoint.position, Vector3.up, 90);
        //transform.RotateAround(edgePivotPoint.position, Vector3.up, speed * Time.deltaTime);
    }

    public void Close()
    {
        open = false;
        //transform.RotateAround(edgePivotPoint.position, Vector3.up, -90);
        //transform.RotateAround(edgePivotPoint.position, Vector3.up, -speed * Time.deltaTime);
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
