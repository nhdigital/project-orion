using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupController : MonoBehaviour
{

    public float powerupSpeed;
    public float rotateSpeed;

    private void Update()
    {
        transform.Translate(Vector3.back * powerupSpeed * Time.deltaTime, Space.World);
        transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime, Space.World);
        if (transform.position.z < -3.5f)
        {
            Destroy(gameObject);
        }
    }



    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Environment"))
        {
            Debug.Log("POWER UP DESTROYED ON SPAWN WITH " + other.gameObject.name);
            Destroy(gameObject);
        }
    }
}
