using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawning : MonoBehaviour
{
    public GameObject EnemyOne;   //Alien      //Het object dat je wilt spawnen
    public GameObject EnemyTwo;   // Spider
    public GameObject EnemyThree;  // Eye
    public GameObject EnemyFour; //skull
    public GameObject EnemyFive; //cooling cat

    public float SpawnInterval = 5f;    //Interval tussen de spawns
    private float LastSpawnTIme;        //Tijd van de laatste spawn
    private GameManager GameManagerScript;
    [SerializeField] private float MaxEnemies; // max enemies set amount
    // The max of the enemies
    public float CurrentEnemies = 0;
    public float CurrentEyes = 0;
    public float CurrentSpiders = 0;
    public float CurrentSkulls = 0;
    public float CurrentCoolingCats = 0;
    public float CurrentSuns = 0;

    private void Start()
    {
        GameManagerScript = FindFirstObjectByType<GameManager>();
    }

    void Update()
    {
        // Spawns enemies every once in a while
        if (Time.time >= LastSpawnTIme + SpawnInterval)
        {
            SpawnObject();
            LastSpawnTIme = Time.time;
        }
    }

    void SpawnObject()
    {
        // Gets random position for enemies
        Vector3 RandomPosition = new Vector3(Random.Range(0, 23), Random.Range(-9, 13), 0);
        // sees if there is no other enemies on the position
        Collider[] ColliderArray = Physics.OverlapSphere(RandomPosition, 0);
        if (ColliderArray.Length == 0)
        {
            if (GameManagerScript.CurrentScore <= 49)
            {
                // Spawn requirements and spawning of enemies
                if (EnemyOne != null && CurrentEnemies < MaxEnemies)
                {
                    Instantiate(EnemyOne, RandomPosition, EnemyOne.transform.rotation);
                    CurrentEnemies += 1;
                }
                else if (EnemyOne == null || EnemyTwo == null || EnemyThree == null)
                {
                    print("Cannot Spawn (GameManager Script)");
                }
                else
                {

                }

                if (GameManagerScript.CurrentScore > 14 && CurrentSpiders < MaxEnemies + 1)
                {
                    RandomPosition = new Vector3(Random.Range(0, 23), Random.Range(-9, 13), 0);
                    Instantiate(EnemyTwo, RandomPosition, EnemyTwo.transform.rotation);
                    CurrentSpiders += 1;
                }

                if (GameManagerScript.CurrentScore > 19 && CurrentEyes < MaxEnemies - 2)
                {
                    RandomPosition = new Vector3(Random.Range(0, 23), Random.Range(-9, 13), 0);
                    Instantiate(EnemyThree, RandomPosition, EnemyThree.transform.rotation);
                    CurrentEyes += 1;
                }

                if (GameManagerScript.CurrentScore > 9 && CurrentSkulls < MaxEnemies - 2)
                {
                    RandomPosition = new Vector3(Random.Range(0, 23), Random.Range(-11, 7), 0);
                    Instantiate(EnemyFour, RandomPosition, EnemyFour.transform.rotation);
                    CurrentSkulls += 1;
                }

                if (GameManagerScript.CurrentScore > 29 && CurrentCoolingCats < MaxEnemies - 2)
                {
                    RandomPosition = new Vector3(Random.Range(-2, 5), Random.Range(-7, 11), 0);
                    Instantiate(EnemyFive, RandomPosition, EnemyFive.transform.rotation);
                    CurrentCoolingCats += 1;
                }
            }
        }
    }
}
