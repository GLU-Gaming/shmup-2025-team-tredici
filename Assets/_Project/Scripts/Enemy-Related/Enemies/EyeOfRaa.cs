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
}
