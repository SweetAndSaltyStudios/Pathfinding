using UnityEngine;

namespace Sweet_And_Salty_Studios
{
    public class GridManager : MonoBehaviour
    {
        #region VARIABLES

        public Vector2 WorldSize;
        public float NodeRadius = 1f;

        private float nodeDiameter;
        private int gridSizeX;
        private int gridSizeY;

        public Node SelectedNode;
        private Node startingNode;
        private Node targetNode;

        private Node[,] grid;

        #endregion VARIABLES

        #region PROPERTIES

        #endregion PROPERTIES

        #region UNITY_FUNCTIONS

        private void Awake()
        {
            Initialize();
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawWireCube(transform.position, new Vector2(WorldSize.x, WorldSize.y));

            if(grid == null)
            {
                return;
            }

            foreach(var node in grid)
            {
                Gizmos.color = node.IsWalkable ? Color.white : Color.red;
                Gizmos.DrawCube(node.WorldPosition, Vector2.one * (nodeDiameter - (nodeDiameter * 0.1f)));
            }
        }
        #endregion UNITY_FUNCTIONS

        #region CUSTOM_FUNCTIONS

        private void Initialize()
        {
            nodeDiameter = NodeRadius * 2;
            gridSizeX = Mathf.RoundToInt(WorldSize.x / nodeDiameter);
            gridSizeY = Mathf.RoundToInt(WorldSize.y / nodeDiameter);
        }

        public void CreateGrid()
        {
            grid = new Node[gridSizeX, gridSizeY];

            var gridBottomLeft =
                transform.position -
                Vector3.right * WorldSize.x * 0.5f -
                Vector3.up * WorldSize.y * 0.5f;

            for(int x = 0; x < gridSizeX; x++)
                for(int y = 0; y < gridSizeY; y++)
                {
                    var worldPoint =
                        gridBottomLeft +
                        Vector3.right * (x * nodeDiameter + NodeRadius) +
                        Vector3.up * (y * nodeDiameter + NodeRadius);

                    var isWalkable = !Physics2D.CircleCast(worldPoint, NodeRadius, Vector2.zero);

                    grid[x, y] = new Node(worldPoint, isWalkable);
                }
        }

        private Node GetNodeAtPosition(int x, int y)
        {
            if(x < 0 || x > WorldSize.x - 1 || y < 0 || y > WorldSize.y - 1)
            {
                return null;
            }

            return grid[x, y];
        }

        #endregion CUSTOM_FUNCTIONS
    }
}
