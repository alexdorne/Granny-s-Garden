using JetBrains.Annotations;
using UnityEngine;

public class GetTilesScript : MonoBehaviour
{
    private float lookRotationAngle;

    public Tile TileInFront {  get; private set; }

    GridManager gridManager;

    private Tile tileUnder;


    private void Awake()
    {
        gridManager = GridManager.Instance;
    }
    private void Update()
    {
        lookRotationAngle = transform.rotation.eulerAngles.y;

        var results = GetTileInFront();

        if (results != null)
        {
            Debug.Log($"X: {results.TileXPos}, Z: {results.TileZPos}");

        }

    }


    private Tile GetTileUnder()
    {
        RaycastHit hit; 

        if (Physics.Raycast(transform.position, Vector3.down, out hit, Mathf.Infinity))
        {
            GameObject hitObject = hit.collider.gameObject; 

            if (hitObject != null && hitObject.CompareTag("Tile"))
            {
                return hitObject.GetComponent<Tile>();
            }
        }

        return null;
    }

    private Tile GetTileInFront()
    {
        tileUnder = GetTileUnder(); 

        if (tileUnder != null)
        {
            int tileUnderX = tileUnder.TileXPos; 
            int tileUnderZ = tileUnder.TileZPos;   

            var results = GetTileInFrontCoordinates(tileUnderX, tileUnderZ);

            Tile tileToPass = gridManager.tiles[results.x, results.z]; 

            if (tileToPass != null)
            {
                return tileToPass; 
            }

        }

        return null; 
    }

    private (int x, int z) GetTileInFrontCoordinates(int x, int z)
    {
        int xAdded = 0; 
        int zAdded = 0; 

        if (lookRotationAngle > 315 && lookRotationAngle <= 45)
        {
            zAdded = 1; 
        }
        else if (lookRotationAngle > 45 && lookRotationAngle <= 135)
        {
            xAdded = 1; 
        }
        else if (lookRotationAngle > 135 && lookRotationAngle <= 225)
        {
            zAdded = -1; 
        }
        else if (lookRotationAngle > 225 && lookRotationAngle <= 315)
        {
            xAdded = -1; 
        }

        return (xAdded + x, zAdded + z);    

    }
}
