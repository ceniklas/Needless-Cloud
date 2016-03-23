using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour
{

    private float speed = 3.0f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        //float moveHorizontal = Input.GetAxis("Horizontal");
        //float moveVertical = Input.GetAxis("Vertical");
        float moveHorizontal = Random.value;
        float moveVertical = Random.value;

        Debug.Log("X: " + Input.GetAxis("Horizontal") + " Y: " + Input.GetAxis("Vertical"));

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }
}