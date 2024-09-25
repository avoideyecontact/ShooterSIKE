using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbMovement : MonoBehaviour
{
    public float rotationSpeed = 50f;
    public float amplitude = 0.3f;
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
