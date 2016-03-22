using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Maze : MonoBehaviour {

    [System.Serializable]
    private class Cell{
        public bool visited;
        public GameObject north;
        public GameObject east;
        public GameObject south;
        public GameObject west;
    }

    public GameObject wall;
    
    public float wallLength = 1.0f;
    public int xSize = 5;
    public int ySize = 5;
    public bool InvokeInsteadofLoop = false;
    private int totalCells = 0;
    private int visitedCells = 0;
    private bool startedBuilding;

    private Vector3 initialPosition;
    private GameObject wallHolder;

    private Cell[] cells;
    private int currentCell = 0;
    private int currentNeighbour = 0;
    private List<int> lastCells;
    private int backingUp = 0;
    private int wallToBreak;
    

    // Use this for initialization
    void Start () {
        CreateWalls();
        CreateCells();
        CreateMaze();
        
	}



    void CreateWalls() {
        wallHolder = new GameObject();
        wallHolder.name = "Maze";

        initialPosition = new Vector3((-xSize / 2) + (wallLength / 2.0f), 0.0f, (-ySize / 2) + (wallLength / 2.0f));
        Vector3 myPos = initialPosition;
        GameObject tempWall;

        //X
        for (int i = 0; i < ySize; i++) {
            for (int j = 0; j < xSize+1; j++)
            {
                myPos = new Vector3(initialPosition.x + (j*wallLength) - (wallLength/2.0f), 0.0f, initialPosition.z + (i*wallLength) - (wallLength/2.0f));
                tempWall = Instantiate(wall, myPos, Quaternion.identity) as GameObject;
                tempWall.transform.parent = wallHolder.transform;
            }
        }

        //Y
        for (int i = 0; i < ySize+1; i++) {
            for (int j = 0; j < xSize; j++)
            {
                myPos = new Vector3(initialPosition.x + (j * wallLength), 0.0f, initialPosition.z + (i * wallLength) - (wallLength));
                tempWall = Instantiate(wall, myPos, Quaternion.Euler(0.0f, 90.0f, 0.0f)) as GameObject;
                tempWall.transform.parent = wallHolder.transform;
            }
        }
    }

    void CreateCells() {
        totalCells = xSize * ySize;
        int children = wallHolder.transform.childCount;
        GameObject[] allWalls = new GameObject[children];
        cells = new Cell[xSize * ySize];
        lastCells = new List<int>();
        int eastWestProcess = 0;
        int childProcess = 0;
        int termCount = 0;

        for (int i = 0; i < children; i++) {
            allWalls[i] = wallHolder.transform.GetChild(i).gameObject;
        }

        for (int cellprocess = 0; cellprocess < cells.Length; cellprocess++) {
            if (termCount == xSize) {
                eastWestProcess++;
                termCount = 0;
            }

            cells[cellprocess] = new Cell();
            cells[cellprocess].east = allWalls[eastWestProcess];
            cells[cellprocess].south = allWalls[childProcess + ((xSize+1) * ySize)];

            eastWestProcess++;
            termCount++;
            childProcess++;

            cells[cellprocess].west = allWalls[eastWestProcess];
            cells[cellprocess].north = allWalls[childProcess + ((xSize + 1) * ySize) + xSize-1];
        }
    }

    void CreateMaze() {

        if (InvokeInsteadofLoop)
        {
            if (visitedCells < totalCells) {
                if (startedBuilding) {
                    GiveMeNeighbour();
                    if (cells[currentNeighbour].visited == false && cells[currentCell].visited == true) {
                        BreakWall();
                        cells[currentNeighbour].visited = true;
                        visitedCells++;
                        lastCells.Add(currentCell);
                        currentCell = currentNeighbour;

                        if (lastCells.Count > 0) {
                            backingUp = lastCells.Count - 1;
                        }
                    }
                }
                else {
                    currentCell = UnityEngine.Random.Range(0, totalCells);
                    cells[currentCell].visited = true;
                    visitedCells++;
                    startedBuilding = true;
                }

                Invoke("CreateMaze", 0.0f); 

            }
        }
        else
        {
            while (visitedCells < totalCells) {
                if (startedBuilding) {
                    GiveMeNeighbour();
                    if (cells[currentNeighbour].visited == false && cells[currentCell].visited == true) {
                        BreakWall();
                        cells[currentNeighbour].visited = true;
                        visitedCells++;
                        lastCells.Add(currentCell);
                        currentCell = currentNeighbour;

                        if (lastCells.Count > 0) {
                            backingUp = lastCells.Count - 1;
                        }
                    }
                }
                else {
                    currentCell = UnityEngine.Random.Range(0, totalCells);
                    cells[currentCell].visited = true;
                    visitedCells++;
                    startedBuilding = true;
                }
            }
        }

        GiveMeNeighbour();
    }

    private void BreakWall() {
        switch (wallToBreak)
        {
            case 1:
                Destroy(cells[currentCell].north);
                break;
            case 2:
                Destroy(cells[currentCell].east);
                break;
            case 3:
                Destroy(cells[currentCell].south);
                break;
            case 4:
                Destroy(cells[currentCell].west);
                break;

            default:
                break;
        }

    }

    void GiveMeNeighbour() {
        int length = 0;
        int[] neighbours = new int[4];
        int[] connectingWall = new int[4];
        int check = (currentCell+1) / xSize;
        check -= 1;
        check *= xSize;
        check += xSize;

        //West
        if(currentCell+1 < totalCells && (currentCell+1) != check) {
            if(cells[currentCell+1].visited == false) {
                neighbours[length] = currentCell + 1;
                connectingWall[length] = 4;
                length++;
            }
        }

        //East
        if (currentCell - 1 >= 0 && currentCell != check) {
            if (cells[currentCell - 1].visited == false) {
                neighbours[length] = currentCell - 1;
                connectingWall[length] = 2;
                length++;
            }
        }

        //North
        if (currentCell + xSize < totalCells) {
            if (cells[currentCell + xSize].visited == false) {
                neighbours[length] = currentCell + xSize;
                connectingWall[length] = 1;
                length++;
            }
        }

        //South
        if (currentCell - xSize >= 0) {
            if (cells[currentCell - xSize].visited == false) {
                neighbours[length] = currentCell - xSize;
                connectingWall[length] = 3;
                length++;
            }
        }

        if(length != 0) {
            int theChosenOne = UnityEngine.Random.Range(0, length);
            currentNeighbour = neighbours[theChosenOne];
            wallToBreak = connectingWall[theChosenOne];
        }
        else {
            if(backingUp > 0) {
                currentCell = lastCells[backingUp];
                backingUp--;
            }
        }
    }

    // Update is called once per frame
    void Update () {
	
	}
}
