using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public static SceneManager Instance { get; private set; }
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return ;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
