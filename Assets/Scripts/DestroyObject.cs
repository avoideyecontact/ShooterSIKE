using UnityEngine;

// ����� ��� �������� �������� �� �����
public class DestroyObject : MonoBehaviour
{
    [SerializeField] private GameObject objectToDestroy;

    // ������� ��� �������� ������� �� �����
    public void Destroy()
    {
        Destroy(objectToDestroy);
    }
}
