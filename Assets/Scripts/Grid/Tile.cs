using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] TileData tileData;

    public int TileXPos {  get; set; } 
    public int TileZPos { get; set; }   

}
