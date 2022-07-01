using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ObjektMove : MonoBehaviour
{
    public Vector3 correct_position;
    public bool ready;
    public AudioSource sound_lvl;
    public AudioSource sound_complite;
    public int accur;

    private bool pause = true;
    private GameObject menu_complite;
    private GameObject next;
    private GameObject menu_pause;
    private bool compliteLvl = false;
    private bool object_moove = false;
    private bool move_menu = false;

    private Vector3 move_x = new Vector3(.1f, 0f, 0f);
    private Vector3 move_y = new Vector3(0f, .1f, 0f);
    private Vector3 move_z = new Vector3(0f, 0f, .1f);

    public bool debug = false; //DELETE!!

    void Start()
    {
        sound_lvl.Play();
        menu_complite = GameObject.Find("menu_complite");
        next = GameObject.Find("Next");
        menu_complite.SetActive(false);
        if (next)
            next.SetActive(false);
        menu_pause = GameObject.Find("menu_pause");
        menu_pause.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && pause)
        {
            if (menu_pause.activeSelf)
                menu_pause.SetActive(false);
            else
                menu_pause.SetActive(true);
        }
        if (menu_pause.activeSelf)
            return ;
        if (Input.GetMouseButtonDown(0) || (Input.GetMouseButtonDown(1)))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            Physics.Raycast(ray, out hit);
            if (hit.transform == transform)
                object_moove = true;
            else
                object_moove = false;
            Debug.Log(hit.transform.name);
        }

        if (Input.GetMouseButton(0) && !compliteLvl)
        {
            if (object_moove)
            {
                transform.Rotate(Vector3.right, Input.GetAxis("Mouse Y") * 20, Space.World);
                transform.Rotate(Vector3.down, Input.GetAxis("Mouse X") * 20, Space.World);
            }
        }
        if (Input.GetMouseButton(1) && !compliteLvl)
        {
            
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
        if (!compliteLvl && in_range((int)transform.eulerAngles[0], (int)correct_position[0]) < accur && in_range((int)transform.eulerAngles[1], (int)correct_position[1]) < accur && in_range((int)transform.eulerAngles[2], (int)correct_position[2]) < accur)
        {
            Debug.Log("You Win!");
            sound_complite.Play();
            compliteLvl = true;
            move_menu = true;
        }
        
        if (compliteLvl)
        {
            if (right_move((int)transform.eulerAngles[0], (int)correct_position[0]))
                transform.eulerAngles += move_x;
            else if ((int)transform.eulerAngles[0] != (int)correct_position[0])
                transform.eulerAngles -= move_x;
            if (right_move((int)transform.eulerAngles[1], (int)correct_position[1]))
                transform.eulerAngles += move_y;
            else if ((int)transform.eulerAngles[1] != (int)correct_position[1])
                transform.eulerAngles -= move_y;
            if (right_move((int)transform.eulerAngles[2], (int)correct_position[2]))
                transform.eulerAngles += move_z;
            else if ((int)transform.eulerAngles[2] != (int)correct_position[2])
                transform.eulerAngles -= move_z;
        }
        if (move_menu && ready)
        {
            pause = false;
            menu_complite.SetActive(true);
            if (next)
                next.SetActive(true);
            sound_lvl.Stop();
            menu_complite.transform.GetComponent<RectTransform>().localPosition -= move_y * 30;
            if (menu_complite.transform.GetComponent<RectTransform>().localPosition[1] <= 0)
            {
                LoadScene.save_game();
                move_menu = false;
            }
        }
        if (Input.GetKeyDown("i"))
        {
            Debug.Log("main" + transform.eulerAngles + " " + correct_position);
            Debug.Log(transform.name + " " + transform.position);
        }
    }

    bool right_move(int a, int b)
    {
        if ((a < b && b - a <= accur) || (a > b && a - b > accur))
            return true;
        else 
            return false;
    }

    int in_range(int a, int b)
    {
        return Math.Min(Math.Abs(a - b), Math.Abs(Math.Abs(a - b) - 360));
    }
}