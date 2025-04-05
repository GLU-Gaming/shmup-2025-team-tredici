using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;

public class EnemyBase : MonoBehaviour
{
    public int EnemyMaxHP;
    private int EnemyCurrentHP;
    public GameObject EnemyBullet;
    public float ShootCooldown = 2;
    public float ShootCooldownChangeable = 2;
    public Vector3 moveDirection;
    [SerializeField] public float MoveSpeed;
    [SerializeField] private Transform BulletSpawnPoint;
    [SerializeField] public GameObject DeathParticle;
    [SerializeField] public GameObject DeathAudio;
    public AudioSource Audio;


    public GameManager GameManagerScript;
    public EnemySpawning EnemySpawningScript;
    public GameObject PlayerCharachter;
    public Rigidbody rb;
    private Rigidbody EnemyprojectileRigidBody;

    void Start()
    {
        // Sets stuff and finds stuff for/to the enemy
        ShootCooldown = ShootCooldownChangeable;
        EnemyprojectileRigidBody = EnemyBullet.GetComponent<Rigidbody>();
        Audio = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
        PlayerCharachter = GameObject.FindWithTag("Player");
        GameManagerScript = FindFirstObjectByType<GameManager>();
        EnemySpawningScript = FindFirstObjectByType<EnemySpawning>();
        EnemyCurrentHP = EnemyMaxHP;
    }

    void Update()
    {
        EnemyMovement();
        EnemyAttack();
        // It dies when HP reaches 0
        if (EnemyCurrentHP == 0)
        {
            OnDeath();
        }
        ShootCooldown = ShootCooldown - Time.deltaTime;
    }

    public virtual void EnemyMovement()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
    }

    public virtual void EnemyAttack()
    {
        if (ShootCooldown <= 0)
        {
            // spawns bullet
            GameObject Enemyprojectile = Instantiate(EnemyBullet, BulletSpawnPoint.position, transform.rotation);
            ShootCooldown = 2;
        }
    }

    public virtual void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Projectile>())
        {
            Audio.Play();
            EnemyCurrentHP = EnemyCurrentHP - 1;
        }
    }

    public virtual void OnDeath()
    {
        //This is what happends when the enemy dies
        Audio.Stop();
        DeathAudio.SetActive(true);
        Instantiate(DeathParticle, transform.position, transform.rotation);
        EnemySpawningScript.CurrentEnemies -= 1;
        GameManagerScript.CurrentScore += 1;
        Destroy(gameObject);
    }

}
