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

    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
