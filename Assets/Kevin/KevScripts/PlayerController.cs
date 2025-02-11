using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody playerRigidbody;
    public float speed = 5f;
    private bool isGrounded;

    [Header("Pickup & Throw")]
    public Transform holdPoint; // Where the object will be held
    public float pickupRange = 3f; // Max distance to pick up
    public float throwForce = 10f;
    private GameObject heldObject;
    private Rigidbody heldObjectRb;

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        CheckGround();
        Jump();
        Move();
        HandlePickupAndThrow();
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            playerRigidbody.AddForce(Vector3.up * 5, ForceMode.Impulse);
            Debug.Log("Jump brother!");
        }
    }

    void Move()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        playerRigidbody.MovePosition(transform.position + move * speed * Time.deltaTime);
    }

    void CheckGround()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 1.1f))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }

    void HandlePickupAndThrow()
    {
        if (Input.GetKeyDown(KeyCode.E)) // Pick up or drop
        {
            if (heldObject == null)
            {
                TryPickupObject();
            }
            else
            {
                DropObject();
            }
        }

        if (Input.GetMouseButtonDown(0) && heldObject != null) // Left-click to throw
        {
            ThrowObject();
        }
    }

    void TryPickupObject()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, pickupRange))
        {
            if (hit.collider.CompareTag("Throwable"))
            {
                heldObject = hit.collider.gameObject;
                heldObjectRb = heldObject.GetComponent<Rigidbody>();

                // Disable physics while holding
                heldObjectRb.isKinematic = true;
                heldObjectRb.useGravity = false;

                // Attach to player
                heldObject.transform.SetParent(holdPoint);
                heldObject.transform.localPosition = Vector3.zero;
            }
        }
    }

    void DropObject()
    {
        if (heldObject != null)
        {
            heldObjectRb.isKinematic = false;
            heldObjectRb.useGravity = true;

            heldObject.transform.SetParent(null);
            heldObject = null;
        }
    }

    void ThrowObject()
    {
        if (heldObject != null)
        {
            heldObjectRb.isKinematic = false;
            heldObjectRb.useGravity = true;

            heldObject.transform.SetParent(null);
            heldObjectRb.AddForce(Camera.main.transform.forward * throwForce, ForceMode.Impulse);

            heldObject = null;
        }
    }
}
