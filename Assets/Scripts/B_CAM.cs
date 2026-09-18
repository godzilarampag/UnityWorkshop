
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform player;

    public float distance = 5f;
    public float height = 2f;
    public float mouseSensitivity = 3f;

    float mouseX;
    float mouseY;

    void Update()
    {
        // Mouse movement
        mouseX += Input.GetAxis("Mouse X") * mouseSensitivity;
        mouseY -= Input.GetAxis("Mouse Y") * mouseSensitivity;

        // Limit vertical camera movement
        mouseY = Mathf.Clamp(mouseY, -20f, 60f);
    }

    void LateUpdate()
    {
        // Camera rotation
        Quaternion rotation = Quaternion.Euler(mouseY, mouseX, 0);

        // Camera position
        Vector3 position = player.position + Vector3.up * height;
        position -= rotation * Vector3.forward * distance;

        transform.position = position;

        // Look at player
        transform.LookAt(player.position + Vector3.up * height);
    }
}
