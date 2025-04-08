using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public string SceneName;
    public void GoToGame()
    {
        SceneManager.LoadScene(SceneName);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
