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

    private GameObject menu_complite;
    private bool compliteLvl = false;
    private bool object_moove = false;
    private bool move_menu = false;

    Vector3 mousePos;

    private Vector3 move_x = new Vector3(.1f, 0f, 0f);
    private Vector3 move_y = new Vector3(0f, .1f, 0f);
    private Vector3 move_z = new Vector3(0f, 0f, .1f);

    // private bool x;
    // private bool y;
    // private bool z;

    public bool debug = false; //DELETE!!

    void Start()
    {
        sound_lvl.Play();
        menu_complite = GameObject.Find("menu_complite");
        menu_complite.SetActive(false);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) || (Input.GetMouseButtonDown(1)))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            Physics.Raycast(ray, out hit);
            if (hit.transform == transform)
                object_moove = true;
            else
                object_moove = false;
            Debug.Log(hit.transform.name);
            mousePos = Input.mousePosition;
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
            if (object_moove)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + (Input.mousePosition.y - mousePos.y) / 5000, transform.position.z);
                if (transform.position.y >= 3)
                    transform.position = new Vector3(transform.position.x, 3, transform.position.z);
                if (transform.position.y <= -3)
                    transform.position = new Vector3(transform.position.x, -3, transform.position.z);    
            }
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
            // x = right_move((int)transform.eulerAngles[0], (int)correct_position[0]);
            // y = right_move((int)transform.eulerAngles[1], (int)correct_position[1]);
            // z = right_move((int)transform.eulerAngles[2], (int)correct_position[2]);
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
            menu_complite.SetActive(true);
            sound_lvl.Stop();
            menu_complite.transform.GetComponent<RectTransform>().localPosition -= move_y * 30;
            if (menu_complite.transform.GetComponent<RectTransform>().localPosition[1] <= 0)
                move_menu = false;
        }
        if (Input.GetKeyDown("i"))
        {
            Debug.Log("main" + transform.eulerAngles + " " + correct_position);
            Debug.Log("transform.position " + transform.Find("Circle01").transform.position);
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