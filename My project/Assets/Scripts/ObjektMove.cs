using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ObjektMove : MonoBehaviour
{
    public Vector3 correct_position;
    public AudioSource sound_lvl;
    public AudioSource sound_complite;

    private GameObject menu_complite;
    private bool compliteLvl = false;
    private bool move_menu = false;

    private Vector3 move_x = new Vector3(.1f, 0f, 0f);
    private Vector3 move_y = new Vector3(0f, .1f, 0f);
    private Vector3 move_z = new Vector3(0f, 0f, .1f);

    public bool debug = false; //DELETE!!

    void Start()
    {
        sound_lvl.Play();
        menu_complite = GameObject.Find("menu_complite");
    }

    void Update()
    {
        if (Input.GetMouseButton(0) && !compliteLvl)
        {
            transform.Rotate(Vector3.right, Input.GetAxis("Mouse Y") * 20, Space.World);
            transform.Rotate(Vector3.down, Input.GetAxis("Mouse X") * 20, Space.World);
        }
        if (debug) //Debug
            return;
        if (Input.GetKeyDown("z"))
        {
            if (!compliteLvl)
                compliteLvl = true;
            else
                compliteLvl = false;
        }
        if (!compliteLvl && Math.Abs(transform.eulerAngles[0] - correct_position[0]) < 25 && Math.Abs(transform.eulerAngles[1] - correct_position[1]) < 25 && Math.Abs(transform.eulerAngles[2] - correct_position[2]) < 25)
        {
            Debug.Log("You Win!");
            sound_lvl.Stop();
            sound_complite.Play();
            compliteLvl = true;
            move_menu = true;
        }
        if (compliteLvl)
        {
            if ((int)transform.eulerAngles[0] < (int)correct_position[0])
                transform.eulerAngles += move_x;
            else if ((int)transform.eulerAngles[0] > (int)correct_position[0])
                transform.eulerAngles -= move_x;
            if ((int)transform.eulerAngles[1] < (int)correct_position[1])
                transform.eulerAngles += move_y;
            else if ((int)transform.eulerAngles[1] > (int)correct_position[1])
                transform.eulerAngles -= move_y;
            if ((int)transform.eulerAngles[2] < (int)correct_position[2])
                transform.eulerAngles += move_z;
            else if ((int)transform.eulerAngles[1] > (int)correct_position[1])
                transform.eulerAngles -= move_z;
        }
        if (move_menu)
        {
            menu_complite.transform.GetComponent<RectTransform>().localPosition -= move_y * 6;
            if (menu_complite.transform.GetComponent<RectTransform>().localPosition[1] <= 0)
                move_menu = false;
        }
        if (Input.GetKeyDown("i"))
        {
            Debug.Log(transform.eulerAngles + " " + correct_position);
            Debug.Log(menu_complite.transform.GetComponent<RectTransform>().localPosition);
        }
    }
}


