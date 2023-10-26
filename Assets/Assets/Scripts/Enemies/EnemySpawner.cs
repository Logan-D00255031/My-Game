using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // Original code from pratical classes and modified for personal use
    [Header("Spawn Settings")]
    [SerializeField] private GameObject enemyPrefab; 
    [SerializeField] private float spawnRate = 2f; 
    [SerializeField] private Transform[] spawnPoints; 
    [SerializeField] public GameObject playerToFollow;

    [Header("Limit Settings")]
    [SerializeField] private int maxEnemies = 5; 
    private int currentEnemies = 0; 

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy", spawnRate, spawnRate);
    }
    void SpawnEnemy(){
        if(currentEnemies >= maxEnemies) return; 

        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        GameObject spawnedEnemy = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);

        // Tell spawned enemy what game object to follow
        EnemyMovement enemyMovement = spawnedEnemy.GetComponent<EnemyMovement>();
        enemyMovement.player = playerToFollow;

        currentEnemies++;
    }
    public void EnemyDied(){
        currentEnemies--;
    }
}
