using UnityEngine;

public class BossArms : MonoBehaviour
{
    private GameManager gameManager;

    void Start()
    {
        gameManager = FindFirstObjectByType<GameManager>();
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        gameManager.CurrentLifes -= 1;
    }
}
