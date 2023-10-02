using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PowerupManager : MonoBehaviour
{
    public static PowerupManager instance;
    public GameObject[] powerups;

    public bool hasBoost;
    public bool hasGhost;
    public bool hasMultiplier;
    public bool hasFreeze;

    private float spawnXBound = 0.98f;
    private float spawnZBound = 3.5f;
    private float spawnYBound = 0.273f;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(instance);
        }
    }



    // SPAWN MANAGEMENT LOGIC



    private void Start()
    {
        InvokeRepeating("SpawnPowerUp", 5, 6);
    }

    private void SpawnPowerUp()
    {

        if (!hasBoost && !hasFreeze && !hasGhost && !hasMultiplier)
        {
            Vector3 spawnPos = new Vector3(Random.Range(-spawnXBound, spawnXBound), spawnYBound, spawnZBound);
            int powerupIndex = Random.Range(0, powerups.Length);
            GameObject powerupGO = Instantiate(powerups[powerupIndex], spawnPos, transform.rotation);
        }
    }















// BOOLEAN COROUTINES - GLOBALISED DUE TO SINGLETON

    public IEnumerator SpeedBoostActive()
    {
        Debug.Log("Speed Boost Active!");
        hasBoost = true;
        yield return new WaitForSeconds(5);
        hasBoost = false;
        Debug.Log("Speed Boost Inactive!");
    }

    public IEnumerator GhostActive()
    {
        Debug.Log("Ghost Active!");
        hasGhost = true;
        yield return new WaitForSeconds(5);
        hasGhost = false;
        Debug.Log("Ghost Inactive!");
    }

    public IEnumerator MultiplierActive()
    {
        Debug.Log("Multiplier Active!");
        hasMultiplier = true;
        yield return new WaitForSeconds(5);
        hasMultiplier = false;
        Debug.Log("Multiplier Inactive!");
    }

    public IEnumerator FreezeActive()
    {
        Debug.Log("Freeze Active!");
        hasFreeze = true;
        yield return new WaitForSeconds(5);
        hasFreeze = false;
        Debug.Log("Freeze Inactive!");
    }


}
