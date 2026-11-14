using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 8f;
    public float jumpForce = 6f;

    private Rigidbody rb;
    private bool onGround = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && onGround)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            onGround = false;
        }
    }

    

void FixedUpdate()
{
    float x = Input.GetAxisRaw("Horizontal");
    float z = Input.GetAxisRaw("Vertical");

    Vector3 movement = new Vector3(x, 0, z).normalized;

    Vector3 velocity = rb.linearVelocity;

    Vector3 targetVelocity = movement * speed;

    Vector3 velocityChange = targetVelocity - new Vector3(velocity.x, 0, velocity.z);

    rb.AddForce(velocityChange * 8f, ForceMode.Acceleration);
}



    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            onGround = true;
        }
    }
}