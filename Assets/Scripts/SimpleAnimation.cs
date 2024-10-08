using UnityEngine;

// ����� ������� �������� ����������� ������� ������� �� ����� ���
public class SimpleAnimation : MonoBehaviour
{
    // ��������� ��������
    public float amplitude;

    // ������� �������� ��� ������ ���
    public float frequencyX;
    public float frequencyY;
    public float frequencyZ;

    private Quaternion initialRotation;

    void Start()
    {
        initialRotation = transform.localRotation;
    }

    void Update()
    {
        float xOffset = Mathf.Sin(Time.time * frequencyX) * amplitude;
        float yOffset = Mathf.Sin(Time.time * frequencyY) * amplitude;
        float zOffset = Mathf.Sin(Time.time * frequencyZ) * amplitude;
        transform.localRotation = Quaternion.Euler(initialRotation.x + xOffset, initialRotation.y + yOffset, initialRotation.z + zOffset);
    }
}
