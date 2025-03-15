using UnityEngine;

[CreateAssetMenu(fileName = "NewPlacedObjectData", menuName = "Grid/PlacedObjectData")]
public class PlacedObjectData : ScriptableObject
{
    public string objectName; 
    public GameObject prefab;
    public bool canGrow; 

}
