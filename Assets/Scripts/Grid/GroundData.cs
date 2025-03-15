using UnityEngine;

[CreateAssetMenu(fileName = "NewGroundData", menuName = "Grid/GroundData")]
public class GroundData : ScriptableObject
{
    public string tileName; 
    public GameObject tilePrefab; 
    public GroundType groundType; 

    public enum GroundType
    {
        Soil,
        Sand,
        Rocks,
        Water
    }

}
