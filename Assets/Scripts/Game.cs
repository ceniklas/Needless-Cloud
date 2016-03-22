using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour {

    public GameObject MainCamera;
    public GameObject MazeGenerator;

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


        //Instantiate(lightGameObject, transform.position, transform.rotation);

    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
