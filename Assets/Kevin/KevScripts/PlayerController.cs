using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Rigidbody playerRigidbody;
    public float speed = 5f;
    private bool isGrounded;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckGround();
        Jump();
        Move();
        
    }

        void Jump(){
            //Makes the player jump with the space bar
           
            if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
            {
                playerRigidbody.AddForce(Vector3.up * 5, ForceMode.Impulse);
                Debug.Log("Jump brother!");
            }
        }


        void Move(){
            //Makes the player move with the arrow keys
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 move = transform.right * x + transform.forward * z;

            playerRigidbody.MovePosition(transform.position + move * speed * Time.deltaTime);
        }

        void CheckGround(){


            //Checks if the player is grounded
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
    


}
