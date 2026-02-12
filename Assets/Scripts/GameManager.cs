using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public Level currentLevel;
    
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return ;
        }
        Instance = this;
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void SetLevel(Level level)
    {
        currentLevel = level;
    }
}
