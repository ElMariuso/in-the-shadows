using UnityEngine;

[CreateAssetMenu(fileName = "New Level", menuName = "GameData/New Level")]
public class Level : ScriptableObject
{
    public short id = 0;
    public GameObject objectPrefab;
    
    [Header("Spawn")]
    public Vector3 spawnPosition;
    public Vector3 spawnRotation;
    
    [Header("Gameplay")]
    public Vector3 correctRotation;
    public bool ignoreX, ignoreY, ignoreZ;
}
