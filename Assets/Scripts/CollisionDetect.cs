using UnityEngine;
using System.Collections;



public class CollisionDetect : MonoBehaviour
{

    public static bool Hit = false;
    public static Vector3 Wall = new Vector3(0, 0, 0);

    public void Awake()
    {

        Wall = new Vector3(0, 0, 0);
        Hit = false;

    }

    void OnCollisionEnter(Collision collision)
    {

        ContactPoint contact = collision.contacts[0];
        Wall = contact.normal;
        Hit = true;

    }

    void OnCollisionExit(Collision collisionInfo)
    {
        Hit = false;

    }

}