
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    public float fallThreshold = -10f;

    private Vector3 startPosition;
    private Rigidbody rb;
    private bool isRespawning = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startPosition = transform.position;
    }

    void FixedUpdate()
    {
        if (!isRespawning && rb.position.y < fallThreshold)
        {
            Respawn();
        }
    }

    void Respawn()
    {
        isRespawning = true;

        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        rb.position = startPosition;
        transform.position = startPosition;

        isRespawning = false;
    }
}
