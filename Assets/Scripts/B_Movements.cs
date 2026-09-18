
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float rotationSpeed = 10f;
    public float gravity = 9.8f;
    public float jumpForce = 5f;

    public Transform cameraTransform;

    float verticalVelocity;

    void Update()
    {
        float horizontal = 0;
        float vertical = 0;

        // WASD
        if (Input.GetKey(KeyCode.W))
        {
            vertical = 1;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            vertical = -1;
        }

        if (Input.GetKey(KeyCode.A))
        {
            horizontal = -1;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            horizontal = 1;
        }

        // Camera directions
        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;

        // Don't allow camera looking up/down to affect movement
        forward.y = 0;
        right.y = 0;

        forward.Normalize();
        right.Normalize();

        // Movement direction
        Vector3 moveDirection = forward * vertical + right * horizontal;

        // Move
        if (moveDirection.magnitude > 0)
        {
            transform.position += moveDirection.normalized * speed * Time.deltaTime;

            // Rotate player toward movement direction
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);

            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                targetRotation,
                rotationSpeed * Time.deltaTime
            );
        }

        // Gravity
        verticalVelocity -= gravity * Time.deltaTime;

        // Jump
        if (Input.GetKeyDown(KeyCode.Space) && transform.position.y <= 0.01f)
        {
            verticalVelocity = jumpForce;
        }

        // Apply gravity
        transform.position += Vector3.up * verticalVelocity * Time.deltaTime;

        // Ground
        if (transform.position.y < 0)
        {
            transform.position = new Vector3(
                transform.position.x,
                0,
                transform.position.z
            );

            verticalVelocity = 0;
        }
    }
}

