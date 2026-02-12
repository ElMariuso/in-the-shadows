using UnityEngine;

public class MenuButton : MonoBehaviour
{
    public void MoveToLevelMenu()
    {
        GameManager.Instance.LoadScene("LevelMenu");
    }
    
    public void QuitButton()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
