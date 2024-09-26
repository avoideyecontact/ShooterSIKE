using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float runMultiplier;
    public float jumpSpeed;

    private CharacterController characterController;
    private float ySpeed;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        float runInput = Input.GetAxis("Run");

        Vector3 movementDirection = transform.forward * verticalInput + transform.right * horizontalInput;

        float magnitude = Mathf.Clamp01(movementDirection.magnitude) * speed;
        movementDirection.Normalize();

        if (characterController.isGrounded)
        {
            ySpeed = -0.5f;

            if (Input.GetButton("Jump"))
            {
                ySpeed = jumpSpeed;
            }
        }
        else
        {
            ySpeed += Physics.gravity.y * Time.deltaTime * 2;
        }

        if (runInput > 0)
        {
            magnitude = magnitude * runMultiplier;
        }

        Vector3 velocity = movementDirection * magnitude;
        velocity.y = ySpeed;


        characterController.Move(velocity * Time.deltaTime);
    }
}
