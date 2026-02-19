using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public string sceneName;
    
    public void RestartGame()
    {
        SceneManager.LoadScene(sceneName);
    }
}
