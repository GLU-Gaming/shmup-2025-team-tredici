using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] public float MCSpeed;
    [SerializeField] GameObject Bullet;
    GameManager gameManager;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        gameManager = FindFirstObjectByType<GameManager>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            gameManager.CurrentLifes = gameManager.CurrentLifes - 1;
        }

        if (collision.gameObject.CompareTag("Boss"))
        {
            gameManager.CurrentLifes = gameManager.CurrentLifes - 1;
        }
    }
}
