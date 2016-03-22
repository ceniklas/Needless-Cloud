using UnityEngine;
using System.Collections;
using System;

public class Game : MonoBehaviour {

    public GameObject MainCamera;
    public GameObject MazeGenerator;


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
        //Instantiate(lightGameObject, transform.position, transform.rotation);

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

        theCamera.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 3.0f, player.transform.position.z);

    }

    void CreatePlayer()
    {
        player = new GameObject();
        player.name = "Player";
        GameObject.CreatePrimitive(PrimitiveType.Sphere).transform.SetParent(player.transform);
        player.transform.position = new Vector3(0.5f, 0, 0);
        player.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);

        player.AddComponent<Rigidbody>();

        PlayerController p = player.AddComponent<PlayerController>();
        p.speed = 4.0f;
    }
}
