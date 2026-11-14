
using UnityEngine;

public class RandomBounce : MonoBehaviour
{
    [Range(0f, 1f)]
    public float bounceChance = 0.5f;

    public float bounceForce = 12f;
    public float horizontalForce = 10f;

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
            return;

        if (Random.value > bounceChance)
            return;

        Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();

        if (rb == null) return;

        Vector3 direction = Random.insideUnitSphere;
        direction.y = 0f;
        direction.Normalize();

        Vector3 velocity = rb.linearVelocity;
        rb.linearVelocity = new Vector3(0f, velocity.y, 0f);

        Vector3 force = direction * horizontalForce
                      + Vector3.up * bounceForce;

        rb.AddForce(force, ForceMode.Impulse);
    }
}
