using Unity.VisualScripting;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public int EnemyMaxHP;
    private int EnemyCurrentHP;
    GameManager GameManagerScript;
    EnemySpawning EnemySpawningScript;

    void Start()
    {
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

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Projectile>())
        {
            EnemyCurrentHP = EnemyCurrentHP - 1;
        }
    }

}
