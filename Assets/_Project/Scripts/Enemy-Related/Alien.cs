using UnityEngine;

public class Alien : EnemyBase
{
    public override void EnemyMovement()
    {
        // Goes towards you 
        base.EnemyMovement();
        EnemyMaxHP = 3;
    }

    public override void EnemyAttack()
    {
        // Just shoots
        base.EnemyAttack();
    }

}
