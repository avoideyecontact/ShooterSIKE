using UnityEngine;
using UnityEngine.Events;

public class RaycastInteraction : MonoBehaviour
{
    public float interactionDistance;

    [SerializeField] private Transform cameraTransform;
    //[SerializeField] private UnityEvent _action;

    void OnDrawGizmos()
    {
        Vector3 endPosition = cameraTransform.position + cameraTransform.forward * interactionDistance;

        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(cameraTransform.position, endPosition - cameraTransform.position);
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            RaycastHit hit;
            if (Physics.Raycast(cameraTransform.position, cameraTransform.forward, out hit, interactionDistance))
            {
                Debug.Log("Int");
                IInteractable interactable = hit.collider.GetComponent<IInteractable>();
                interactable?.Interact();
            }
        }
    }

    public void Raycast()
    {

    }
}
