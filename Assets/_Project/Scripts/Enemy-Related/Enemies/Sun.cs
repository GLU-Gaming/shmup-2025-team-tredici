using UnityEngine;

public class Sun : EnemyBase
{
    public override void OnDeath()
    {
        GameManagerScript.CurrentScore += 2;
        EnemySpawningScript.CurrentSuns -= 1;
        Destroy(gameObject);
    }

    public override void EnemyAttack()
    {
        //buffs others
    }

    public override void EnemyMovement()
    {
        // floats around
    }
}
