using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public void GameStart(int scene)
    {
        SceneManager.LoadScene(scene, LoadSceneMode.Additive);
    }
    public void Exit()
    {
        Application.Quit();
    }
}