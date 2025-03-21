using Unity.VisualScripting;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public int EnemyMaxHP;
    private int EnemyCurrentHP;
    public GameObject EnemyBullet;
    private float ShootCooldown = 2;
    [SerializeField] private Transform BulletSpawnPoint;
    

    GameManager GameManagerScript;
    EnemySpawning EnemySpawningScript;
    private GameObject PlayerCharachter;
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
        EnemyAttack();
        // It dies when HP reaches 0
        if (EnemyCurrentHP == 0)
        {
            EnemySpawningScript.CurrentEnemies -= 1;
            GameManagerScript.CurrentScore += 1;
            Destroy(gameObject);
        }
        ShootCooldown = ShootCooldown - Time.deltaTime;
    }

    public virtual void EnemyMovement()
    {

    }

    public virtual void EnemyAttack()
    {
        if (ShootCooldown <= 0)
        {
            // spawns bullet
            GameObject Enemyprojectile = Instantiate(EnemyBullet, BulletSpawnPoint.position, Quaternion.identity);
            ShootCooldown = 2;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Projectile>())
        {
            EnemyCurrentHP = EnemyCurrentHP - 1;
        }
    }

}
