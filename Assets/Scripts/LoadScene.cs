using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class LoadScene : MonoBehaviour
{   
    public static bool save;
    public static int save_lvl;


    void Update()
    {
        if (Input.GetKeyDown("i"))
        {
            
        }    
    }

    public void LoadLvlSave()
    {
        string lvl_str;

        save = true;
        try
        {
            if (File.Exists(".save"))
            {
                StreamReader sr = new StreamReader(".save");
                lvl_str = sr.ReadLine();
                save_lvl = System.Convert.ToInt32(lvl_str);
                Debug.Log(save_lvl + " " + lvl_str);
                SceneManager.LoadScene(save_lvl, LoadSceneMode.Single);
            }
            else
            {
                // File.Create(".save");
                StreamWriter sw = new StreamWriter(".save");
                sw.WriteLine("1");
                sw.Close();
                save_lvl = 1;
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

    public static void save_game()
    {
        if (save)
        {
            StreamWriter sw = new StreamWriter(".save");
            sw.WriteLine(System.Convert.ToString(++save_lvl));
            sw.Close();
        }
    }

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