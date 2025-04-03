using UnityEngine;
using static UnityEditor.PlayerSettings;

public class CoolingCar : EnemyBase
{
    public override void EnemyAttack()
    {
        //n/a
    }


    public override void EnemyMovement()
    {
        EnemyMaxHP = 1;
        //N/A
    }

    public override void OnDeath()
    {
        EnemySpawningScript.CurrentCoolingCats -= 1;
        GameManagerScript.CurrentScore += 1;
        Destroy(gameObject);
    }

    public override void OnCollisionEnter(Collision collision)
    {
        //print(collision.contacts[0].thisCollider.name);

        if (collision.gameObject.GetComponent<Projectile>())
        {
            if (collision.contacts[0].thisCollider.name.Contains("PF_cooling-car"))
            {
                OnDeath();
            }
        }

    }
}
