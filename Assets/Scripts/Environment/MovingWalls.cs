using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingWalls : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 0.6f;

    private void Update()
    {
        if (PowerupManager.instance.hasFreeze)
        {
            moveSpeed = 0f;
        }
        else
        {
            moveSpeed = 0.6f;
        }

        transform.Translate(Vector3.back * Time.deltaTime * moveSpeed, Space.World);

        if (transform.position.z < -3.5f)
        {
            Destroy(gameObject);
        }
    }
}
