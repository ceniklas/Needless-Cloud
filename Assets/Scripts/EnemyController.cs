using UnityEngine;
using System.Collections;
using System;

public class EnemyController : MonoBehaviour
{

    private float speed = 3.0f;
    Vector3 movement;

    private Rigidbody rb;
    PathFinder path;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //path = new PathFinder();
        movement = new Vector3(1.0f, 0.0f, 0.0f);
    }

    void FixedUpdate()
    {
        //float moveHorizontal = Input.GetAxis("Horizontal");
        //float moveVertical = Input.GetAxis("Vertical");

        //movePlayer(movement);
    }
    
    private void movePlayer(Vector3 direction)
    {
        //rb.AddForce(direction * speed);
    }

    void OnCollisionEnter(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            if (contact.normal.y < 0.2)
            {
                float moveHorizontal = UnityEngine.Random.Range(-1, 1);
                float moveVertical = UnityEngine.Random.Range(-1, 1);

                movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
            }
        }

        //rb.AddForce(movement * speed);

    }
}