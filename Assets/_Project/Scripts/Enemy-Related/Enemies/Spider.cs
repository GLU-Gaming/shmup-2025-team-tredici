using UnityEngine;

public class NewMonoBehaviourScript : EnemyBase
{
    public override void EnemyMovement()
    {
        // Goes towards you 
        base.EnemyMovement();
        EnemyMaxHP = 2;
    }
    public override void EnemyAttack()
    {
        base.EnemyAttack();
    }
}
