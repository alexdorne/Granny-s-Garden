using UnityEngine;

public class GridManager : Singleton<GridManager>
{
    [SerializeField] GameObject tile;
    [SerializeField] int gridWidth; 
    [SerializeField] int gridDepth;

    public Tile[,] tiles { get; private set; }  

    private void Awake()
    {
        tiles = new Tile[10,10]; 

        GenerateGrid();

    }

    private void GenerateGrid()
    {
        for (int x = 0; x < gridWidth; x++)
        {
            for (int z = 0; z < gridDepth; z++)
            {
                var spawnedTile = Instantiate(tile, new Vector3(x + 0.5f, -0.05f, z + 0.5f), Quaternion.identity);
                tiles[x,z] = spawnedTile.GetComponent<Tile>();
                
                Tile tileScript = spawnedTile.GetComponent<Tile>(); 

                tileScript.TileXPos = x;
                tileScript.TileZPos = z;
            }
        }
    }
}
