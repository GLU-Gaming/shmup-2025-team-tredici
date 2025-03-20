using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Rigidbody rb;
    private float speed = 50;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.linearVelocity = transform.forward * speed;
        Destroy(gameObject, 1f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }

}
