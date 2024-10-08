using UnityEngine;

// Движение персонажа
public class PlayerMovement : MonoBehaviour
{
    // Скорость движения
    public float speed;
    // Множитель скорости при беге
    public float runMultiplier;
    // Сила прыжка
    public float jumpSpeed;
    // Направление игрока (куда смотрит)
    public Transform orientation;

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

        Vector3 movementDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

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
