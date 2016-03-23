using UnityEngine;
using System.Collections;
using System;

public class Game : MonoBehaviour {

    public GameObject MainCamera;
    public GameObject MazeGenerator;
    //public GameObject enemy;
    private GameObject player;
    private GameObject theCamera;
    private GameObject miniMap;
    
    // Use this for initialization
    void Start () {

        theCamera = Instantiate(MainCamera, transform.position, transform.rotation) as GameObject;
        theCamera.transform.Translate(new Vector3(0, 3, 0));
        theCamera.transform.Rotate(new Vector3(90, 0, 0));

        miniMap = Instantiate(MainCamera, transform.position, transform.rotation) as GameObject;
        miniMap.transform.Translate(new Vector3(0, 20, 0));
        miniMap.transform.Rotate(new Vector3(90, 0, 0));
        Destroy(miniMap.GetComponent<AudioListener>());
        miniMap.GetComponent<Camera>().depth = 1.0f;
        miniMap.GetComponent<Camera>().rect = new Rect(0.75f, 0.5f, 0.25f, 1);

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
        Enemy enemy1 = new Enemy();
        enemy1.setEnemyLocation(MazeGenerator.GetComponent<Maze>().xSize / 2 - 0.5f, MazeGenerator.GetComponent<Maze>().ySize / 2 - 1.0f);

        Enemy enemy2 = new Enemy();
        enemy2.setEnemyLocation(-MazeGenerator.GetComponent<Maze>().xSize / 2 + 0.5f, MazeGenerator.GetComponent<Maze>().ySize / 2 - 1.0f);

        Enemy enemy3 = new Enemy();
        enemy3.setEnemyLocation(-MazeGenerator.GetComponent<Maze>().xSize / 2 + 0.5f, -MazeGenerator.GetComponent<Maze>().ySize / 2 );

        Enemy enemy4 = new Enemy();
        enemy4.setEnemyLocation(MazeGenerator.GetComponent<Maze>().xSize / 2 - 0.5f, -MazeGenerator.GetComponent<Maze>().ySize / 2 );

    }

    private void CreateGroundPlane()
    {
        GameObject groundPlane = new GameObject();
        groundPlane.name = "Ground";
        GameObject plane = GameObject.CreatePrimitive(PrimitiveType.Plane);
        plane.transform.SetParent(groundPlane.transform);
        groundPlane.transform.position = new Vector3(0, -0.5f, 0);
        groundPlane.transform.localScale = new Vector3(5, 5, 5);


        Material m = new Material(Shader.Find("Standard"));
        //m.color = Color.black;
        //plane.AddComponent<Material>();
        
        
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
        
        theCamera.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 3.0f, player.transform.position.z);


    }

    void CreatePlayer()
    {
        player = new GameObject();
        player.name = "Player";
        GameObject theSpere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        theSpere.transform.SetParent(player.transform);
        player.transform.position = new Vector3(0.5f, 0, 0);
        player.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);

        //theSpere.GetComponent<Collider>()
        SphereCollider playerCollider = player.AddComponent<SphereCollider>();
        playerCollider.isTrigger = true;
        player.AddComponent<Rigidbody>();

        PlayerController p = player.AddComponent<PlayerController>();
        p.speed = 4.0f;
    }
}
