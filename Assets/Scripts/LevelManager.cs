using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private Level level;

    public GameObject spawnedObject;
    public Difficulty actualDifficulty = Difficulty.secondLevel;

    private void Awake()
    {
        level = GameManager.Instance.currentLevel;

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
        
        // Check axis
        if (!level.ignoreX) return CheckAxis(current.x, level.correctX);
        if (!level.ignoreY) return CheckAxis(current.y, level.correctY);

        return true;
    }

    private bool CheckAxis(float currentAxis, List<float> correctAxis, float tolerance = 10f)
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
