using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private Level level;

    public GameObject spawnedObject;
    public Difficulty actualDifficulty = Difficulty.secondLevel;

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        spawnedObject = Instantiate(
            level.objectPrefab,
            level.spawnPosition,
            Quaternion.Euler(level.spawnRotation)
        );
    }
    
    public void OnValidateRotation()
    {
        if (IsCorrect()) Debug.Log("Correct ✅");
        else Debug.Log("Incorrect ❌");
    }
    
    private bool IsCorrect()
    {
        Vector3 current = spawnedObject.transform.eulerAngles;
        float tolerance = 10f;

        // Check axis
        if (!level.ignoreX) return CheckAxis(current.x, level.correctX, tolerance);
        if (!level.ignoreY) return CheckAxis(current.y, level.correctY, tolerance);

        return true;
    }

    private bool CheckAxis(float currentAxis, List<float> correctAxis, float tolerance)
    {
        if (correctAxis == null || correctAxis.Count == 0) return true;
        
        foreach (var axis in correctAxis)
        {
            float delta = Mathf.Abs(Mathf.DeltaAngle(currentAxis, axis));
            
            if (delta <= tolerance) return true;
        }

        return false;
    }
}
