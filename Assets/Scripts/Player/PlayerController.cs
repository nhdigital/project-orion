using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    private InputActions playerInputActions;
    private InputAction movement;

    private Vector2 moveVector;

    private Rigidbody rb;

    public static float speed = 1f;

    private void Awake()
    {
        playerInputActions = new InputActions();
        rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        movement = playerInputActions.Player.Move;
        movement.Enable();
    }

    private void OnDisable()
    {
        movement.Disable();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (PowerupManager.instance.hasBoost)
        {
            speed = 2f;
        }
        else
        {
            speed = 1f;
        }

        moveVector.Set(movement.ReadValue<Vector2>().x, movement.ReadValue<Vector2>().y);
        rb.velocity = new Vector3(moveVector.x, 0, moveVector.y) * speed;
    }






    // POWER UP COLLISION EVENTS
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Boost"))
        {
            Destroy(other.gameObject);
            StartCoroutine(PowerupManager.instance.SpeedBoostActive());
        }
        if (other.gameObject.CompareTag("Multiplier"))
        {
            Destroy(other.gameObject);
            StartCoroutine(PowerupManager.instance.MultiplierActive());
        }
        if (other.gameObject.CompareTag("Ghost"))
        {
            Destroy(other.gameObject);
            StartCoroutine(GhostEffect());
           
        }
        if (other.gameObject.CompareTag("Freeze"))
        {
            Destroy(other.gameObject);
            StartCoroutine(PowerupManager.instance.FreezeActive());
        }
    }



    IEnumerator GhostEffect()
    {
        PowerupManager.instance.hasGhost = true;
        var meshRenderer = gameObject.GetComponent<MeshRenderer>();
        var collider = gameObject.GetComponent<SphereCollider>();
        var color = meshRenderer.material.color;
        color.a = .1f;
        meshRenderer.material.color = color;
        collider.enabled = false;

        yield return new WaitForSeconds(5);

        PowerupManager.instance.hasGhost = false;
        color.a = 1f;
        meshRenderer.material.color = color;
        collider.enabled = true;
    }
  
}

