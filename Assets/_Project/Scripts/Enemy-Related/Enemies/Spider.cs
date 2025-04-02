using Unity.Mathematics;
using UnityEngine;
using UnityEngine.EventSystems;

public class Spider : EnemyBase
{
    public override void EnemyMovement()
    {
        EnemyMaxHP = 2;
        ShootCooldownChangeable = 4;

        // The spider goes towards the player and shoots you 
        // CREDITS: https://www.youtube.com/watch?v=ZExSz7x69j8
        if (PlayerCharachter)
        {
            Vector3 direction = (PlayerCharachter.transform.position - transform.position).normalized;
            moveDirection = direction;
            Quaternion LookDirection = Quaternion.LookRotation(direction, Vector3.back) * Quaternion.AngleAxis(90, Vector3.down);
            transform.rotation = Quaternion.Slerp(transform.rotation , LookDirection , Time.deltaTime * 1);
        }
        rb.linearVelocity = transform.right * MoveSpeed; //new Vector3(moveDirection.x, moveDirection.y) * MoveSpeed;
    }
    public override void EnemyAttack()
    {
        base.EnemyAttack();
    }

    public override void OnDeath()
    {
        EnemySpawningScript.CurrentSpiders -= 1;
        GameManagerScript.CurrentScore += 2;
        Destroy(gameObject);
    }
}
