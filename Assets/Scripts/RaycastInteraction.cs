using UnityEngine;

// Взаимодействие с объектами при помощи raycast
public class RaycastInteraction : MonoBehaviour
{
    // Дальность взаимодействия с объектами
    public float interactionDistance;

    [SerializeField] private Transform cameraTransform;

    void OnDrawGizmos()
    {
        Vector3 endPosition = cameraTransform.position + cameraTransform.forward * interactionDistance;

        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(cameraTransform.position, endPosition - cameraTransform.position);
    }

    // Взаимодействие с объектами при помощи raycast
    public void Raycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(cameraTransform.position, cameraTransform.forward, out hit, interactionDistance))
        {
            IInteractable interactable = hit.collider.GetComponent<IInteractable>();
            interactable?.Interact();
        }
    }
}
