using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    public float speed = 3.0f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }

    void OnCollisionEnter(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            if(contact.normal.y < 0.2)
            {
                //collision.transform.Translate(-contact.normal);
            }
        }

    }

    void OnTriggerEnter(Collider target)
    {
        //Vector3 forceVec = target.attachedRigidbody.velocity.normalized * 20.0f;
        //target.attachedRigidbody.AddForce(forceVec, ForceMode.Acceleration);
        
    }
}