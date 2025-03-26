using Unity.VisualScripting;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public int EnemyMaxHP;
    private int EnemyCurrentHP;
    public GameObject EnemyBullet;
    public float ShootCooldown = 2;
    public Vector3 moveDirection;
    [SerializeField] public float MoveSpeed;
    [SerializeField] private Transform BulletSpawnPoint;


    public GameManager GameManagerScript;
    public EnemySpawning EnemySpawningScript;
    public GameObject PlayerCharachter;
    public Rigidbody rb;
    private Rigidbody EnemyprojectileRigidBody;

    void Start()
    {
        // Sets stuff and finds stuff for/to the enemy
        EnemyprojectileRigidBody = EnemyBullet.GetComponent<Rigidbody>();
        rb = GetComponent<Rigidbody>();
        PlayerCharachter = GameObject.FindWithTag("Player");
        GameManagerScript = FindFirstObjectByType<GameManager>();
        EnemySpawningScript = FindFirstObjectByType<EnemySpawning>();
        EnemyCurrentHP = EnemyMaxHP;
    }

    void Update()
    {
        EnemyMovement();
        BulletSpawnPoint.transform.LookAt(PlayerCharachter.transform);
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Projectile>())
        {
            EnemyCurrentHP = EnemyCurrentHP - 1;
        }

        if (collision.gameObject.GetComponent<EnemyBase>())
        {
            Physics.IgnoreCollision(collision.collider, GetComponent<Collider>());
        } else if (collision.gameObject.GetComponent<EnemyBullet>())
        {
            Physics.IgnoreCollision(collision.collider, GetComponent<Collider>());
        }
    }

    public virtual void OnDeath()
    {
        //This is what happends when the enemy dies
        EnemySpawningScript.CurrentEnemies -= 1;
        GameManagerScript.CurrentScore += 1;
        Destroy(gameObject);
    }

}
