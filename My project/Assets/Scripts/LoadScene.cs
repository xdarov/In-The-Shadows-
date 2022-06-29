using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class LoadScene : MonoBehaviour
{   
    public static bool save;


    void Update()
    {
        if (Input.GetKeyDown("i"))
        {
            
        }    
    }

    public void LoadLvlSave()
    {
        int lvl;
        string lvl_str;

        save = true;
        try
        {
            if (File.Exists(".save"))
            {
                StreamReader sr = new StreamReader(".save");
                lvl_str = sr.ReadLine();
                lvl = System.Convert.ToInt32(lvl_str);
                Debug.Log(lvl + " " + lvl_str);
                SceneManager.LoadScene(lvl, LoadSceneMode.Single);
            }
            else
            {
                // File.Create(".save");
                StreamWriter sw = new StreamWriter(".save");
                sw.WriteLine("1");
                sw.Close();
                SceneManager.LoadScene(1, LoadSceneMode.Single);
            }
        }
        catch (System.Exception e)
        {
            Debug.Log("error " + e);
            SceneManager.LoadScene(1, LoadSceneMode.Single);
        }
        
    }

    public void LoadLvlNoSave(int scene)
    {
        save = false;
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }

    public void LoadLvl(int scene)
    {
        if (save && scene != 0)
        {
            StreamWriter sw = new StreamWriter(".save");
            sw.WriteLine(System.Convert.ToString(scene));
            sw.Close();
        }
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