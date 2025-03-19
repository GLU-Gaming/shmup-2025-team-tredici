using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] public float MCSpeed;
    [SerializeField] GameObject Bullet;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            print("apple");
            GameObject SpawnBullet = Instantiate(Bullet, rb.transform);
        }
    }

    private void FixedUpdate()
    {
        if (Input.GetAxis("Vertical") > 0)
        {
            rb.AddRelativeForce(new Vector3(0, MCSpeed, 0));
        } else if (Input.GetAxis("Vertical") < 0)
        {
            rb.AddRelativeForce(0, -MCSpeed, 0);
        }

        if(Input.GetAxis("Horizontal") > 0)
        {
            rb.AddRelativeForce(new Vector3(0, 0, MCSpeed));
        } else if (Input.GetAxis("Horizontal") < 0)
        {
            rb.AddRelativeForce(0, 0, -MCSpeed);
        }
    }
}
