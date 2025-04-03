using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class BossScript : MonoBehaviour
{

    private int MaxHealth = 10;
    public int CurrentHealth;
    public GameManager GameManager;
    private Rigidbody rb;
    public float ShootCooldown = 2;
    [SerializeField] private GameObject eyebrow;
    [SerializeField] private GameObject Bulletpopup;
    [SerializeField] private GameObject Hands;
    [SerializeField] private Transform BulletSpawnPoint;
    private int SwoopSpeed = 6;
    private bool IsAttackTwoActive = false;

    private Vector3 CurrentPosition;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        CurrentHealth = MaxHealth;
    }

    void Update()
    {
        if (CurrentHealth == 0)
        {
            SceneManager.LoadScene(4);
        }
        ShootCooldown = ShootCooldown - Time.deltaTime;

        //AttackOne();
        Attacktwo();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Projectile>())
        {
            CurrentHealth -= 1;
        }

        if (collision.gameObject.tag == "Border_Walls" && IsAttackTwoActive == true)
        {
            rb.transform.position = CurrentPosition;
        };
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
        IsAttackTwoActive = true;
        CurrentPosition = transform.position;
        rb.AddRelativeForce (new Vector3(Random.Range(-23, 20), Random.Range(-8, 11), 0) * SwoopSpeed);


    }

    void AttackThree()
    {
        // hands
    }
}
