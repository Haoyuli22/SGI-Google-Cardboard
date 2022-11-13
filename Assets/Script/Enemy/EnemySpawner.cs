using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject[] enemyPrefabs = null;
    public Transform target = null;

    public int maxSpawn = 20;

    private int currentlySpawned = 0;

    public float spawnDelay = 2f;

    private float spawnWait = 15f;

    private bool waiting = false;
    public float waitCounter = 0;

    // The most recent spawn time
    private float lastSpawnTime = Mathf.NegativeInfinity;

    public float spawnRangeZ = 5.0f;


    public void ResetSpawner(int max)
    {
        maxSpawn = max;
        currentlySpawned = 0;
    }

    private void Update()
    {
        if (waiting) {
            //Debug.Log("Paro");
            waitCounter += Time.deltaTime;
            if (waitCounter >= spawnWait) {
                waiting = false;
                waitCounter = 0;
            }
        }

        else { 
            CheckSpawnTimer();
        }
    }

    private void CheckSpawnTimer()
    {
        // If it is time for an enemy to be spawned
        if (Time.timeSinceLevelLoad > lastSpawnTime + spawnDelay && (currentlySpawned < maxSpawn))
        {
            // Determine spawn location
            Vector3 spawnLocation = GetSpawnLocation();

            // Spawn an enemy
            SpawnEnemy(spawnLocation);
            CheckPawnNumber();

        }
    }

    private void CheckPawnNumber() {
        //Wait (5)+Level
        if (currentlySpawned % 5 == 0) {
            waiting = true;
        }
    
    }

    /// <param name="spawnLocation">The location to spawn an enmy at</param>
    private void SpawnEnemy(Vector3 spawnLocation)
    {

        // Make sure the prefab is valid
        if (enemyPrefabs != null)
        {
            int randomEnemy = Random.Range(0, enemyPrefabs.Length);
            GameObject enemyPrefab = enemyPrefabs[randomEnemy];
            // Create the enemy gameobject
            GameObject enemyGameObject = Instantiate(enemyPrefab, spawnLocation, enemyPrefab.transform.rotation, null);
            Enemy enemy = enemyGameObject.GetComponent<Enemy>();

            // Setup the enemy if necessary
            if (enemy != null)
            {
                enemy.followTarget = target;
            }

            // Incremment the spawn count
            currentlySpawned++;
            lastSpawnTime = Time.timeSinceLevelLoad;
        }
    }


    protected virtual Vector3 GetSpawnLocation()
    {
        float z = Random.Range(0 - spawnRangeZ, spawnRangeZ);
        return new Vector3(transform.position.x, transform.position.y, transform.position.z + z);
    }
}
