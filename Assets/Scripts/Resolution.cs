using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Resolution : MonoBehaviour
{
    public Dropdown Dropdown;

    void Start()
    {
        Screen.SetResolution(1920, 1080, true);
    }

    public void ChangeResolution()
    {
        if (Dropdown.value == 0)
        {
            Screen.SetResolution(1920, 1080, true);
        }
        else if (Dropdown.value == 1)
        {
            Screen.SetResolution(2560, 1440, true);
        }
    } 
}
