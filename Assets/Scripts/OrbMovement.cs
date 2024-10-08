using UnityEngine;

// Движение орбов для красоты
public class OrbMovement : MonoBehaviour
{
    // Скорость вращения орбов
    public float rotationSpeed = 50f;
    // Аплитуда движения орбов (вверх - вниз)
    public float amplitude = 0.3f;
    // Частота движения орбов (вверх - вниз)
    public float frequency = 2f;

    private Vector3 initialPosition;

    void Start()
    {
        initialPosition = transform.localPosition;
    }

    void Update()
    {
        transform.localRotation = transform.localRotation * Quaternion.Euler(0, rotationSpeed * Time.deltaTime, 0);

        float yOffset = Mathf.Sin(Time.time * frequency) * amplitude;
        transform.localPosition = new Vector3(initialPosition.x, initialPosition.y + yOffset, initialPosition.z);
    }
}
