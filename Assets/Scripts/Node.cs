﻿using UnityEngine;
using System.Collections;

public class Node {

    public bool walkable;
    public Vector3 worldPosition;
    public int gCost;
    public int hCost;
    public Node parent;
    public int gridX;
    public int gridY;

    public Node(bool _walkable, Vector3 _worldPos)
    {
        walkable = _walkable;
        worldPosition = _worldPos;
    }

    public int fCost
    {
        get
        {
            return gCost + hCost;
        }
    }
}
