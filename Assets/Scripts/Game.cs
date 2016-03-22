using UnityEngine;
using System.Collections;
using System;

public class Game : MonoBehaviour {

    public GameObject MainCamera;
    public GameObject MazeGenerator;
    public GameObject player;

    public GameObject enemy;

    // Use this for initialization
    void Start () {

        GameObject theCam = Instantiate(MainCamera, transform.position, transform.rotation) as GameObject;
        theCam.transform.Translate(new Vector3(0, 20, 0));
        theCam.transform.Rotate(new Vector3(90, 0, 0));

        GameObject theMaze = Instantiate(MazeGenerator, transform.position, transform.rotation) as GameObject;

        GameObject lightGameObject = new GameObject("The Light");
        Light lightComp = lightGameObject.AddComponent<Light>();
        lightComp.type = LightType.Directional;
        //lightComp.color = Color.blue;
        lightGameObject.transform.position = new Vector3(0, 5, 0);
        lightGameObject.transform.Rotate(new Vector3(90, 0, 0));

        CreatePlayer();
        CreateGroundPlane();
        CreateEnemies();
        //Instantiate(lightGameObject, transform.position, transform.rotation);

    }

    void CreateEnemies()
    {
        enemy = new GameObject();
        enemy.name = "Enemy";
        GameObject.CreatePrimitive(PrimitiveType.Sphere).transform.SetParent(enemy.transform);
        enemy.GetComponent<Renderer>().material.color = Color.blue;
        enemy.transform.position = new Vector3(5.5f, 0, 0);
        enemy.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
    }

    private void CreateGroundPlane()
    {
        GameObject groundPlane = new GameObject();
        groundPlane.name = "Ground";
        GameObject.CreatePrimitive(PrimitiveType.Plane).transform.SetParent(groundPlane.transform);
        groundPlane.transform.position = new Vector3(0, -0.5f, 0);
        groundPlane.transform.localScale = new Vector3(5, 5, 5);
    }

    // Update is called once per frame
    void Update () {

        /*
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) 
        {
            player.transform.Translate(new Vector3(0,0,0.1f));
        }

        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            player.transform.Translate(new Vector3(0, 0, -1));
        }

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
            {
                player.transform.Translate(new Vector3(0, 0, 0.1f));
            }
            
            if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
            {
                player.transform.Translate(new Vector3(0, 0, -0.1f));
            }

            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            {
                player.transform.Translate(new Vector3(-0.1f, 0, 0));
            }

            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            {
                player.transform.Translate(new Vector3(0.1f, 0, 0));
            }
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            player.transform.Translate(new Vector3(1, 0, 0));
        }
        */
        

    }

    void CreatePlayer()
    {
        player = new GameObject();
        player.name = "Player";
        GameObject.CreatePrimitive(PrimitiveType.Sphere).transform.SetParent(player.transform);
        player.transform.position = new Vector3(0.5f, 0, 0);
        player.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);

        player.AddComponent<Rigidbody>();

        PlayerController p;
        p = player.AddComponent<PlayerController>();
    }
}
