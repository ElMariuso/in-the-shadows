using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Level", menuName = "GameData/New Level")]
public class Level : ScriptableObject
{
    public GameObject objectPrefab;
    
    [Header("Spawn")]
    public Vector3 spawnPosition;
    public Vector3 spawnRotation;
    
    [Header("Gameplay")]
    public Difficulty difficulty = Difficulty.secondLevel;
    public List<float> correctX;
    public List<float> correctY;
    public List<float> correctZ;
    public float tolerance = 15f;
    
    public bool ignoreX, ignoreY, ignoreZ;
}
