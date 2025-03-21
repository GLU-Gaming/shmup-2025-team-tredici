using NUnit.Framework;
using UnityEngine;

public class EnemyBulletDestroy : MonoBehaviour
{
    Rigidbody rb;
    private int ShootSpeed = 10;
    private GameManager manager;
    private GameObject Player;

    void Start()
    {
        Player =  GameObject.FindWithTag("Player");
        manager = FindFirstObjectByType<GameManager>();
        rb = GetComponent<Rigidbody>();
        Destroy(gameObject, 5f);
        Vector3 direction = (Player.transform.position).normalized;
        rb.linearVelocity = direction * ShootSpeed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
  
        } else if (collision.gameObject.CompareTag("Player"))
        {
            manager.CurrentLifes -= 1;
            Destroy(gameObject);
        } else
        {
            Destroy(gameObject);
        }
    }
}
