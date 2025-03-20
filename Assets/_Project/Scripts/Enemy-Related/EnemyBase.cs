using Unity.VisualScripting;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public int EnemyMaxHP;
    private int EnemyCurrentHP;
    [SerializeField] private GameObject EnemyBullet;

    GameManager GameManagerScript;
    EnemySpawning EnemySpawningScript;
    private GameObject PlayerCharachter;
    public Rigidbody rb;

    void Start()
    {
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
        if (EnemyCurrentHP == 0)
        {
            EnemySpawningScript.CurrentEnemies -= 1;
            Destroy(gameObject);
        }
    }

    public virtual void EnemyMovement()
    {

    }

    public virtual void EnemyAttack()
    {
        Vector3 direction = PlayerCharachter.transform.position;

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Projectile>())
        {
            EnemyCurrentHP = EnemyCurrentHP - 1;
        }
    }

}
