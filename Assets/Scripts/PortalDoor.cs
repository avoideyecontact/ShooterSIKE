using UnityEngine;

// ���������� �����
public class PortalDoor : MonoBehaviour
{
    [SerializeField] private Transform destination;

    // ���������������� �������
    public void Teleport(GameObject target)
    {
        if (destination == null)
            return;

        var controller = target.GetComponent<CharacterController>();
        controller.enabled = false;
        controller.transform.position = destination.position;
        controller.transform.rotation = destination.rotation;
        controller.enabled = true;
    }
}
