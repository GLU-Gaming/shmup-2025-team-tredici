using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class BossScript : MonoBehaviour
{

    private int MaxHealth = 10;
    public int CurrentHealth;
    public GameManager GameManager;
    private Rigidbody rb;
    public float ShootCooldown = 2;
    [SerializeField] private GameObject eyebrow;
    [SerializeField] private GameObject Bulletpopup;
    [SerializeField] private GameObject Hands;
    [SerializeField] private Transform BulletSpawnPoint;

    private Vector3 CurrentPosition;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        CurrentHealth = MaxHealth;
    }

    void Update()
    {
        if (CurrentHealth == 0)
        {
            SceneManager.LoadScene(4);
        }
        ShootCooldown = ShootCooldown - Time.deltaTime;

        AttackOne();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Projectile>())
        {
            CurrentHealth -= 1;
        }
    }


    void AttackOne()
    {
        if (ShootCooldown <= 0)
        {
            // spawns bullet
            GameObject Enemyprojectile = Instantiate(Bulletpopup, BulletSpawnPoint.position, transform.rotation);
            ShootCooldown = 1;
        }
    }

    void Attacktwo()
    {
        // swoop across screen
        CurrentPosition = transform.position;
        rb.AddRelativeForce (new Vector3(Random.Range(-2, 5), Random.Range(-7, 11), 0));
        transform.position = CurrentPosition;
    }

    void AttackThree()
    {
        // hands
    }
}
