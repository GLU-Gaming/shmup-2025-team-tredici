using UnityEngine;
using UnityEngine.EventSystems;

public class Spider : EnemyBase
{
    public override void EnemyMovement()
    {
        EnemyMaxHP = 2;

        // The spider goes towards the player and shoots you 
        // CREDITS: https://www.youtube.com/watch?v=ZExSz7x69j8
        if (PlayerCharachter)
        {
            Vector3 direction = (PlayerCharachter.transform.position - transform.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;    
             moveDirection = direction;
        }
        rb.linearVelocity = new Vector3(moveDirection.x, moveDirection.y) * MoveSpeed;
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
