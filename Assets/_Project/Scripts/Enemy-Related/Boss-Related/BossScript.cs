using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEditor.PlayerSettings;
using Random = UnityEngine.Random;

public class BossScript : MonoBehaviour
{

    private int MaxHealth = 100;
    public int CurrentHealth;
    public GameManager GameManager;
    private Rigidbody rb;
    public float ShootCooldown = 0.5f;
    [SerializeField] private GameObject eyebrow;
    [SerializeField] private GameObject Bulletpopup;
    [SerializeField] private GameObject Hands;
    [SerializeField] private Transform BulletSpawnPoint;
    [SerializeField] private GameObject AttackTwoPopUp;
    [SerializeField] private float Interval;
    public float Waittime = 0;
    private int RandomAttack;
    private int SwoopSpeed = 10;
    private bool IsAttackTwoActive = false;
    private bool IsAttackThreeActive = false;

    private Vector3 ReturnAttackTwoPosition = new Vector3(15, 0, 0);

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        CurrentHealth = MaxHealth;
        RandomAttack = Random.Range(1, 3);
    }

    void Update()
    {
        Waittime += Time.deltaTime;

        if (CurrentHealth == 0)
        {
            SceneManager.LoadScene(4);
        }
        ShootCooldown = ShootCooldown - Time.deltaTime;

        if (IsAttackTwoActive == true)
        {
            AttackTwoPopUp.SetActive(true);
        }
        else
        {
            AttackTwoPopUp.SetActive(false);
        }

        if (IsAttackThreeActive == true)
        {
            Hands.SetActive(true);
        }
        else
        {
            Hands.SetActive(false);
        }


        if (Waittime >= Interval)
        {
            print("Apple");
            DisableOtherAttacks();
            RandomAttack = Random.Range(1, 3);
            Waittime -= Interval;
        }

        if (RandomAttack == 1)
        {
            AttackOne();
           Vector3 pos = transform.position;
            transform.position = new Vector3(Mathf.Sin(Time.time) * 15, pos.y, pos.z);
        }
        else if (RandomAttack == 2)
        {
            Attacktwo();
        }
        else if (RandomAttack == 3)
        {
            AttackThree();
        }
        else
        {
            print("RandomAttack error");
        }


    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Projectile>())
        {
            CurrentHealth -= 1;
        }

        if (collision.gameObject.CompareTag("Border_Walls") && IsAttackTwoActive == true)
        {
            //rb.AddRelativeForce  (new Vector3(transform.position.x - ReturnAttackTwoPosition.x , transform.position.y - ReturnAttackTwoPosition.y , 0) * SwoopSpeed);
            transform.position = new Vector3(15, Random.Range(-5, 9), 0);
        };
    }


    void AttackOne()
    {
        if (ShootCooldown <= 0)
        {
            // spawns bullet
            GameObject Enemyprojectile = Instantiate(Bulletpopup, BulletSpawnPoint.position, transform.rotation);
            ShootCooldown = 0.5f;
        }


    }

    void Attacktwo()
    {
        // swoop across screen
        IsAttackTwoActive = true;
        rb.AddRelativeForce(new Vector3(Random.Range(-23, 19), 0, 0) * SwoopSpeed);
    }

    void AttackThree()
    {
        // hands
        IsAttackThreeActive = true;
        transform.position = new Vector3(-4, 8, 0);

    }

    void DisableOtherAttacks()
    {
        IsAttackThreeActive = false;
        IsAttackTwoActive = false;
    }
}
