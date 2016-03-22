using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour {

    public GameObject MainCamera;
    public GameObject MazeGenerator;
    public GameObject player;
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
        //Instantiate(lightGameObject, transform.position, transform.rotation);

    }

    // Update is called once per frame
    void Update()
    {
        if (CollisionDetect.Hit == true)
        {

            transform.Translate((CollisionDetect.Wall.x) / 1000, 0, (CollisionDetect.Wall.z) / 1000, Space.World);
            float y =  Time.smoothDeltaTime * Input.GetAxis("Horizontal");
            Debug.Log(CollisionDetect.Wall);
            transform.Rotate(0, y, 0);
        }
        else
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

        

    }

    void CreatePlayer()
    {
        player = new GameObject();
        player.name = "Player";
        GameObject.CreatePrimitive(PrimitiveType.Sphere).transform.SetParent(player.transform);
        player.transform.position = new Vector3(0.5f, 0, 0);
        player.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
    }
}
