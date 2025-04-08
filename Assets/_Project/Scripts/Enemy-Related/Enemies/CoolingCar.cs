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
        Carr = true;
        //N/A
    }

    public override void OnDeath()
    {
        Audio.Stop();
        Instantiate(DeathParticle, transform.position, transform.rotation);
        EnemySpawningScript.CurrentCoolingCats -= 1;
        GameManagerScript.CurrentScore += 1;
        Destroy(gameObject);
    }

    public override void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Projectile>())
        {
            if (collision.contacts[0].thisCollider.name.Contains("PF_cooling-car"))
            {
                OnDeath();
            }
        }

    }
}
