using UnityEngine;

public class Skull : EnemyBase
{
    public override void EnemyMovement()
    {
        EnemyMaxHP = 2;
        // The Skull goes towards the player and then 'explodes'
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
       //n/a
    }

    public override void OnDeath()
    {
        EnemySpawningScript.CurrentSkulls -= 1;
        GameManagerScript.CurrentScore += 1;
        Destroy(gameObject);
    }
}
