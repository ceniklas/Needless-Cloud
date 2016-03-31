using UnityEngine;
using System.Collections;

public class Grid : MonoBehaviour
{

    public LayerMask unwalkableMask;
    public Vector2 gridWorldSize; //Hämta från Maze?
    public float nodeRadius; //Bredden på väggen?
    Node[,] grid;
    Node enemyNode;

    float nodeDiameter;
    int gridSizeX, gridSizeY;

    void Start()
    {
        unwalkableMask = LayerMask.GetMask("unwalkablemask");
        nodeDiameter = nodeRadius * 2;
        gridSizeX = Mathf.RoundToInt(gridWorldSize.x / nodeDiameter);
        gridSizeY = Mathf.RoundToInt(gridWorldSize.y / nodeDiameter);
        CreateGrid();

    }

    public void setGridSize(int x, int y)
    {
        gridSizeX = x;
        gridSizeY = y;
        gridWorldSize = new Vector2(x, y);
    }

    public void setNodeRadius(float radius)
    {
        nodeRadius = radius;
    }

    void CreateGrid()
    {
        grid = new Node[gridSizeX, gridSizeY];
        Vector3 worldBottomLeft = transform.position - Vector3.right * gridWorldSize.x / 2 - Vector3.forward * gridWorldSize.y / 2;

        for (int x = 0; x < gridSizeX; x++)
        {
            for (int y = 0; y < gridSizeY; y++)
            {
                Vector3 worldPoint = worldBottomLeft + Vector3.right * (x * nodeDiameter + nodeRadius) + Vector3.forward * (y * nodeDiameter + nodeRadius - 0.5f);
                bool walkable = !(Physics.CheckSphere(worldPoint, nodeRadius, unwalkableMask));

                grid[x, y] = new Node(walkable, worldPoint);
            }
        }
    }

    public Node NodeFromWorldPoint(Vector3 worldPosition)
    {
        float percentX = (worldPosition.x + gridWorldSize.x / 2) / gridWorldSize.x;
        float percentY = (worldPosition.z + gridWorldSize.y / 2) / gridWorldSize.y;
        percentX = Mathf.Clamp01(percentX);
        percentY = Mathf.Clamp01(percentY);

        int x = Mathf.RoundToInt((gridSizeX - 1) * percentX);
        int y = Mathf.RoundToInt((gridSizeY - 1) * percentY);
        return grid[x, y];
    }

    public void setEnemyPosition(Vector3 pos)
    {
        enemyNode = NodeFromWorldPoint(pos);
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(gridWorldSize.x, 1, gridWorldSize.y));
        if (grid != null)
        {

            foreach (Node n in grid)
            {
                Gizmos.color = (n.walkable) ? Color.white : Color.red;
                /*if (enemyNode == n)
                    Gizmos.color = Color.cyan;*/
                Gizmos.DrawCube(n.worldPosition, Vector3.one * (nodeDiameter - .1f));
            }
        }
    }
    void Update()
    {

    }
}