using UnityEngine;
using UnityEngine.SceneManagement;

public class BossScript : MonoBehaviour
{

    private int MaxHealth = 10;
    public int CurrentHealth;
    public GameManager GameManager;
    [SerializeField] private GameObject eyebrow;
    [SerializeField] private GameObject Bulletpopup;

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
    }

    private void OnCollisionEnter(Collision collision)
    {
        CurrentHealth -= 1;
    }


    void AttackOne()
    {
        // popups schieten
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
