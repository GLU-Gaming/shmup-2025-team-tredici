using Unity.VisualScripting;
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
    [SerializeField] private GameObject AttackTwoPopUp;
    private int SwoopSpeed = 6;
    private bool IsAttackTwoActive = false;

    private Vector3 ReturnAttackTwoPosition= new Vector3 (15, 0, 0);

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

        if (IsAttackTwoActive == true)
        {
            AttackTwoPopUp.SetActive(true);
        }
        else
        {
            AttackTwoPopUp.SetActive(false);
        }

        //AttackOne();
        Attacktwo();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Projectile>())
        {
            CurrentHealth -= 1;
        }

        if (collision.gameObject.CompareTag("Border_Walls") && IsAttackTwoActive == true)
        {
            print("touched wall");
            //rb.AddRelativeForce  (new Vector3(transform.position.x - ReturnAttackTwoPosition.x , transform.position.y - ReturnAttackTwoPosition.y , 0) * SwoopSpeed);
            transform.position = new Vector3 (15, 0, 0);
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

            rb.AddRelativeForce(new Vector3(Random.Range(-23, 19), Random.Range(-7, 9), 0) * SwoopSpeed);
    }

    void AttackThree()
    {
        // hands
    }
}
