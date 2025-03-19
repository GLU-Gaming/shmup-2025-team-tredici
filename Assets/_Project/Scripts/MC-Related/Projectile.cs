using UnityEngine;

public class Shooting : MonoBehaviour
{
    private Rigidbody rb;
    private float speed = 5;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.linearVelocity = transform.forward * speed;
        Destroy(gameObject, 1f);
    }

}
