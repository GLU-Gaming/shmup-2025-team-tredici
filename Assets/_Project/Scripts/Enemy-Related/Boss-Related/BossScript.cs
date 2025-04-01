using UnityEngine;
using UnityEngine.SceneManagement;

public class BossScript : MonoBehaviour
{

    private int MaxHealth = 10;
    public int CurrentHealth;
    public GameManager GameManager;


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

    }

    void Attacktwo()
    {

    }

    void AttackThree()
    {

    }
}
