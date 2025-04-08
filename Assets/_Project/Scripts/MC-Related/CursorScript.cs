using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] public float MCSpeed;
    [SerializeField] GameObject Bullet;
    [SerializeField] GameObject hitParticle;
    [SerializeField] GameObject ShootParticle;
    private Shake2 ShakeScript;
    private Shake3 ShakeScript3;
    GameManager gameManager;
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
        gameManager = FindFirstObjectByType<GameManager>();
        ShakeScript = FindFirstObjectByType<Shake2>();
        ShakeScript3 = FindAnyObjectByType<Shake3>();
    }

    void Update()
    {
        // shoots if u left click or spacebar
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            ShakeScript3.StartShake();
            GameObject SpawnBullet = Instantiate(Bullet, rb.transform);
            Instantiate(ShootParticle, new Vector3 (transform.position.x + 3 ,transform.position.y , -2) , Quaternion.identity);

        }
    }

    private void FixedUpdate()
    {
        //movement
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
        // 
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Boss"))
        {
            ShakeScript.StartShake2();
            audioSource.Play();
            gameManager.CurrentLifes = gameManager.CurrentLifes - 1;
            Instantiate(hitParticle, rb.transform);
        }

        if (collision.gameObject.CompareTag("Bullet"))
        {
            ShakeScript.StartShake2();
            audioSource.Play();
            Instantiate(hitParticle, rb.transform);
        }
    }
}
