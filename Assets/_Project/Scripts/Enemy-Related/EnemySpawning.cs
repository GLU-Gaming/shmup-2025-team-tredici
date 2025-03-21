using System;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawning : MonoBehaviour
{
    public GameObject EnemyOne;         //Het object dat je wilt spawnen
    public GameObject EnemyTwo;
    public GameObject EnemyThree;
    public float SpawnInterval = 5f;    //Interval tussen de spawns
    private float LastSpawnTIme;        //Tijd van de laatste spawn
   [SerializeField] private float MaxEnemies;
    public float CurrentEnemies = 0;

    void Update()
    {
        if (Time.time >= LastSpawnTIme + SpawnInterval)
        {
            SpawnObject();
            LastSpawnTIme = Time.time;
        }
    }

    void SpawnObject()
    {
        Vector3 RandomPosition = new Vector3(Random.Range(0, 23), Random.Range(-9, 13), 0);
        Collider[] ColliderArray = Physics.OverlapSphere(RandomPosition, 0);
        if (ColliderArray.Length == 0)
        {
            if (EnemyOne != null && CurrentEnemies < MaxEnemies)
            {
                Instantiate(EnemyOne, RandomPosition, EnemyOne.transform.rotation);
                CurrentEnemies += 1;
            }
            else if (EnemyOne == null)
            {
                print("Cannot Spawn (GameManager Script)");
            }
            else
            {
                print("Max amount of enemies");
            }
        }
    } 

}
