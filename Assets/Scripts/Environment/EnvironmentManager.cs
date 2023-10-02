using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentManager : MonoBehaviour
{
    public GameObject[] walls;
    public GameObject[] coins;

    private float spawnXBound = 0.98f;
    private float spawnZBound = 3.5f;
   


    private void Start()
    {
        InvokeRepeating("SpawnWall", 1, 4);
        InvokeRepeating("SpawnCoin", 3, 1.5f);
    }



    private void SpawnWall()
    {
        if (!PowerupManager.instance.hasFreeze)
        {
            Vector3 spawnPos = new Vector3(Random.Range(-spawnXBound, spawnXBound), 0, spawnZBound);
            Quaternion spawnRotation = Quaternion.Euler(0f, 90f, 0f);
            int randomWall = Random.Range(0, walls.Length);
            GameObject wall = Instantiate(walls[randomWall], spawnPos, spawnRotation);
        }
    }

    private void SpawnCoin()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-spawnXBound, spawnXBound), 0, spawnZBound);

        int randomCoin = Random.Range(0, coins.Length);
        GameObject coin = Instantiate(coins[randomCoin], spawnPos, Quaternion.identity);
    }
}
