using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class MazeProceduralTest : MonoBehaviour {
	
	[System.Serializable]
	private class Cell{
		public bool visited;
		public GameObject north;
		public GameObject east;
		public GameObject south;
		public GameObject west;
	}
	
	public GameObject block;
	public float wallLength = 1.0f;
	public int xSize = 5;
	public int ySize = 5;
	public bool InvokeInsteadofLoop = false;
	private int totalCells = 0;
	private int visitedCells = 0;
	private bool startedBuilding;
	
	private Vector3 initialPosition;
	private GameObject wallHolder;
	
	//private Cell[] cells;
	private GameObject[] blocks;
	private int currentCell = 0;
	private int currentNeighbour = 0;
	private List<int> lastCells;
	private int backingUp = 0;
	private int wallToBreak;
	
	
	// Use this for initialization
	void Start () {
		CreateWalls();
		//CreateCells();
		CreateMaze();
	}
	
	void CreateWalls() {
		wallHolder = new GameObject();
		wallHolder.name = "Maze";
		
		initialPosition = new Vector3((-xSize / 2) + (wallLength / 2.0f), 0.0f, (-ySize / 2) + (wallLength / 2.0f));
		Vector3 myPos = initialPosition;
		GameObject tempWall;

		blocks = new GameObject[xSize * ySize];
		
		//XY
		for (int i = 0; i < ySize; i++) {
			for (int j = 0; j < xSize; j++)
			{
				myPos = new Vector3(initialPosition.x + (j*wallLength) - (wallLength/2.0f), 0.0f, initialPosition.z + (i*wallLength) - (wallLength/2.0f));
				tempWall = Instantiate(block, myPos, Quaternion.identity) as GameObject;
				tempWall.transform.parent = wallHolder.transform;

				tempWall.GetComponent<Renderer>().material.color = new Color(UnityEngine.Random.value,UnityEngine.Random.value,UnityEngine.Random.value);


				int oneDindex = (i * xSize) + j; // Indexes
				blocks[oneDindex] = tempWall;
				Debug.Log("i "+i + " j "+j + " ind "+ oneDindex);
			}
		}
		

	}

	void CreateMaze ()
	{

		float heightScale = 1.0F;
		float xScale = 1.0F;
		float height = heightScale * Mathf.PerlinNoise(Time.time * xScale, 0.0F);
		Vector3 pos = transform.position;
		pos.y = height;
		transform.position = pos;

		//XY
		for (int i = 0; i < ySize; i++) {
			for (int j = 0; j < xSize+1; j++) {
				if(height < 0.2){
					int oneDindex = (i * xSize) + j;
					Destroy(blocks[oneDindex]);
				}
			}
		}


	}	

	
	// Update is called once per frame
	void Update () {
		
	}
}
