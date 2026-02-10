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
        Quaternion target = Quaternion.Euler(level.correctRotation);
        float angle = Quaternion.Angle(spawnedObject.transform.rotation, target);
        
        return angle < 2f;
    }
}
