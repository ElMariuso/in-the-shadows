using System.Collections.Generic;
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
    public List<float> correctX;
    public List<float> correctY;
    
    public bool ignoreX, ignoreY;
}
