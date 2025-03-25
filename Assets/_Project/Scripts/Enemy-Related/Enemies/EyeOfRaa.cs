using UnityEngine;

public class EyeOfRaa : EnemyBase
{
    public override void EnemyMovement()
    {
        // Goes towards you 
        base.EnemyMovement();
        EnemyMaxHP = 6;
    }
    public override void EnemyAttack()
    {
        base.EnemyAttack();
    }

    public override void OnDeath()
    {
        EnemySpawningScript.CurrentEyes -= 1;
        GameManagerScript.CurrentScore += 3;
        Destroy(gameObject);
    }
}
