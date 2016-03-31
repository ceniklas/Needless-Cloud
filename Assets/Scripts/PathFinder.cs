using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PathFinder : MonoBehaviour
{
    Grid grid;

    public PathFinder(int x, int y)
    {
        grid = GetComponent<Grid>();
        grid.setGridSize(x, y);
        grid.setNodeRadius(.1f);
    }

    void Awake()
    {
        
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