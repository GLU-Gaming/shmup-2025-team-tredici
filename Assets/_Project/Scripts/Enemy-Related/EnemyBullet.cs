using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    Rigidbody rb;
    private int ShootSpeed = 10;
    private GameManager manager;
    private GameObject Player;

    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        manager = FindFirstObjectByType<GameManager>();
        rb = GetComponent<Rigidbody>();
        Destroy(gameObject, 5f);
        Vector3 direction = (Player.transform.position).normalized;
        rb.linearVelocity = direction * ShootSpeed;
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            Player.GetComponent<Movement>().StartInvinc();
            manager.CurrentLifes -= 1;
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

}
