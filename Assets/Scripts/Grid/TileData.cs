using UnityEngine;

[CreateAssetMenu(fileName = "NewTileData", menuName = "Grid/TileData")]
public class TileData : ScriptableObject
{
    public GroundData GroundData;
    public PlacedObjectData PlacedObjectData;
}
