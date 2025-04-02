using UnityEngine;
using UnityEngine.SceneManagement;

public class BossScript : MonoBehaviour
{

    private int MaxHealth = 10;
    public int CurrentHealth;
    public GameManager GameManager;
    public float ShootCooldown = 2;
    [SerializeField] private GameObject eyebrow;
    [SerializeField] private GameObject Bulletpopup;
    [SerializeField] private GameObject Hands;
    [SerializeField] private Transform BulletSpawnPoint;

    private Vector3 CurrentPosition;

    void Start()
    {
        CurrentHealth = MaxHealth;
    }

    void Update()
    {
        if (CurrentHealth == 0)
        {
            SceneManager.LoadScene(4);
        }
        ShootCooldown = ShootCooldown - Time.deltaTime;

        AttackOne();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Projectile>())
        {
            CurrentHealth -= 1;
        }
    }


    void AttackOne()
    {
        if (ShootCooldown <= 0)
        {
            // spawns bullet
            GameObject Enemyprojectile = Instantiate(Bulletpopup, BulletSpawnPoint.position, transform.rotation);
            ShootCooldown = 1;
        }
    }

    void Attacktwo()
    {
        // swoop across screen
    }

    void AttackThree()
    {
        // hands
    }
}
