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

}
