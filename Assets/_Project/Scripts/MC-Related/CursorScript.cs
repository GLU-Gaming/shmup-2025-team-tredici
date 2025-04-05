using Unity.VisualScripting;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] public float MCSpeed;
    [SerializeField] GameObject Bullet;
    [SerializeField] GameObject hitParticle;
    [SerializeField] GameObject ShootParticle;
    GameManager gameManager;
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
        gameManager = FindFirstObjectByType<GameManager>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject SpawnBullet = Instantiate(Bullet, rb.transform);
            Instantiate(ShootParticle, rb.transform);
        }
    }

    private void FixedUpdate()
    {
        if (Input.GetAxis("Vertical") > 0)
        {
            rb.AddRelativeForce(new Vector3(0, MCSpeed, 0));
        }
        else if (Input.GetAxis("Vertical") < 0)
        {
            rb.AddRelativeForce(0, -MCSpeed, 0);
        }

        if (Input.GetAxis("Horizontal") > 0)
        {
            rb.AddRelativeForce(new Vector3(0, 0, MCSpeed));
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            rb.AddRelativeForce(0, 0, -MCSpeed);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            audioSource.Play();
            gameManager.CurrentLifes = gameManager.CurrentLifes - 1;
            Instantiate(hitParticle, rb.transform);
        }

        if (collision.gameObject.CompareTag("Boss"))
        {
            audioSource.Play();
            gameManager.CurrentLifes = gameManager.CurrentLifes - 1;
            Instantiate(hitParticle, rb.transform);
        }

        if (collision.gameObject.CompareTag("Bullet"))
        {
            audioSource.Play();
            Instantiate(hitParticle, rb.transform);
        }
    }
}
