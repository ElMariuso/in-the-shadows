using UnityEngine;

public class LevelButton : MonoBehaviour
{
    [SerializeField] private Level level;

    public void StartLevel()
    {
        GameManager.Instance.SetLevel(level);
        GameManager.Instance.LoadScene("Level");
    }
}
