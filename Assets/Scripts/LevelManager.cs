using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private Level level;

    public GameObject spawnedObject;
    public Difficulty actualDifficulty;

    private void Awake()
    {
        level = GameManager.Instance.currentLevel;
        actualDifficulty = level.difficulty;

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
        if (IsCorrect())
        {
            Debug.Log("Correct ✅");
            GameManager.Instance.LoadScene("LevelMenu");
        }
        else Debug.Log("Incorrect ❌");
    }
    
    private bool IsCorrect()
    {
        Vector3 current = NormalizeEuler(spawnedObject.transform.eulerAngles);

        bool isXCorrect = level.ignoreX || CheckAxis(current.x, level.correctX, level.tolerance);
        bool isYCorrect = level.ignoreY || CheckAxis(current.y, level.correctY, level.tolerance);
        bool isZCorrect = level.ignoreZ || CheckAxis(current.z, level.correctZ, level.tolerance);

        return isXCorrect && isYCorrect && isZCorrect;
    }

    private bool CheckAxis(float currentAxis, List<float> correctAxis, float tolerance)
    {
        if (correctAxis == null || correctAxis.Count == 0)
            return true;

        foreach (var axis in correctAxis)
        {
            float delta = Mathf.Abs(Mathf.DeltaAngle(currentAxis, axis));
            if (delta <= tolerance)
                return true;
        }

        return false;
    }
    
    private Vector3 NormalizeEuler(Vector3 euler)
    {
        return new Vector3(
            NormalizeAngle(euler.x),
            NormalizeAngle(euler.y),
            NormalizeAngle(euler.z)
        );
    }

    private float NormalizeAngle(float angle)
    {
        angle %= 360f;
        
        if (angle < 0f) angle += 360f;
        
        return angle;
    }
}
