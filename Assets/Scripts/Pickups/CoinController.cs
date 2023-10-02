using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    public CoinScriptableObject coinAttributes;
    public float coinSpeed;
   

    private void Update()
    {
        transform.Translate(Vector3.back * coinSpeed * Time.deltaTime, Space.World);
        if (transform.position.z < -3.5f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            GameManager.instance.UpdateScore(coinAttributes.pointsWorth);
        }

        if (!PowerupManager.instance.hasFreeze)
        {
            if (other.gameObject.CompareTag("Environment") || other.gameObject.CompareTag("Pickup"))
            {
                Destroy(gameObject);
                Debug.Log(gameObject.name + " Destroyed coin due to collision on spawn!");
            }
        }
       
    }
}
