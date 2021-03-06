﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PathFinder : MonoBehaviour
{
    Grid grid;
    private Transform seeker, target;

    void Awake()
    {
        
    }
    
    void Start()
    {
        grid = gameObject.GetComponent<Grid>();
    }

    void Update()
    {
        target = GameObject.Find("Player").transform;
        seeker = GameObject.Find("Enemy").transform;

        //Debug.Log("S: " + seeker.position.ToString() + " T: " + target.position.ToString());
        
        FindPath(seeker.position, target.position);
    }

    void FindPath(Vector3 startPos, Vector3 targetPos)
    {
        Node startNode = grid.NodeFromWorldPoint(startPos);
        Node targetNode = grid.NodeFromWorldPoint(targetPos);

        List<Node> openSet = new List<Node>();
        HashSet<Node> closedSet = new HashSet<Node>();
        openSet.Add(startNode);

        //Debug.Log("OP Count: " + openSet.Count);

        while (openSet.Count > 0)
        {
            Node currentNode = openSet[0];
            for (int i = 1; i < openSet.Count; i++)
            {
                //Debug.Log("Looping openSet");
                if (openSet[i].fCost < currentNode.fCost || openSet[i].fCost == currentNode.fCost && openSet[i].hCost < currentNode.hCost)
                {
                    currentNode = openSet[i];
                }
            }

            //Debug.Log(currentNode.worldPosition.ToString());

            openSet.Remove(currentNode);
            closedSet.Add(currentNode);

            if (currentNode == targetNode)
            {
                RetracePath(startNode, targetNode);
                return;
            }

            //Debug.Log("NR of neig" + grid.GetNeighbours(currentNode).Count);

            foreach (Node neighbour in grid.GetNeighbours(currentNode))
            {
                if (!neighbour.walkable || closedSet.Contains(neighbour))
                {
                    continue;
                }

                int newMovementCostToNeighbour = currentNode.gCost + GetDistance(currentNode, neighbour);
                
                if (newMovementCostToNeighbour < neighbour.gCost || !openSet.Contains(neighbour))
                {
                    neighbour.gCost = newMovementCostToNeighbour;
                    neighbour.hCost = GetDistance(neighbour, targetNode);
                    neighbour.parent = currentNode;

                    if (!openSet.Contains(neighbour))
                        openSet.Add(neighbour);
                }
            }
        }


    }

    void RetracePath(Node startNode, Node endNode)
    {
        List<Node> path = new List<Node>();
        Node currentNode = endNode;

        while (currentNode != startNode)
        {
            path.Add(currentNode);
            currentNode = currentNode.parent;
        }
        path.Reverse();

        grid.path = new List<Node>(path);

    }

    int GetDistance(Node nodeA, Node nodeB)
    {
        int dstX = Mathf.Abs(nodeA.gridX - nodeB.gridX);
        int dstY = Mathf.Abs(nodeA.gridY - nodeB.gridY);

        if (dstX > dstY)
            return 14 * dstY + 10 * (dstX - dstY);
        return 14 * dstX + 10 * (dstY - dstX);
    }

    /*
    private class State
    {

    }

    private class Action
    {

    }


    /// <summary>
    /// Should return a estimate of shortest distance. The estimate must me admissible (never overestimate)
    /// </summary>
    float Heuristic(State fromLocation, State toLocation)
    {
        return 0;
    }

    /// <summary>
    /// Return the legal moves from a state
    /// </summary>
    List<Action> Expand(State position)
    {
        return new List<Action>();
    }

    /// <summary>
    /// Return the actual cost between two adjecent locations
    /// </summary>
    float ActualCost(State fromLocation, Action action)
    {
        return 0;
    }

    /// <summary>
    /// Returns the new state after an action has been applied
    /// </summary>
    State ApplyAction(State location, Action action)
    {
        return new State();
    }
    */
}