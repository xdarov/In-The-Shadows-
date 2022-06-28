using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public void LoadLvl(int scene)
    {
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void ResetScene()
    {
    }
}