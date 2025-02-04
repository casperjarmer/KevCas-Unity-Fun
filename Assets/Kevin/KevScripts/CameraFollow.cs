using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public float mouseSensitivity = 200f; // Adjust sensitivity
    public Transform playerBody; // Reference to the player's body

    private float xRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Hide and lock cursor
    }

    void Update()
    {
        // Get mouse input
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Rotate camera up/down (clamp to prevent flipping)
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Rotate the player body left/right
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
