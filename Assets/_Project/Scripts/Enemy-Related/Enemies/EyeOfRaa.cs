using System.Security.Claims;
using UnityEngine;

public class EyeOfRaa : EnemyBase
{
    Vector3 pos;
    public override void EnemyMovement()
    {
        EnemyMaxHP = 6;

        pos = transform.position;
        transform.position = new Vector3(pos.x, Mathf.Sin(Time.time) * 10, pos.z);

    }
    public override void EnemyAttack()
    {
        base.EnemyAttack();
    }

    public override void OnDeath()
    {
        Audio.Stop();
        Instantiate(DeathParticle, transform.position, transform.rotation);
        EnemySpawningScript.CurrentEyes -= 1;
        GameManagerScript.CurrentScore += 3;
        Destroy(gameObject);
    }
}
