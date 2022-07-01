using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ObjektMove2 : MonoBehaviour
{
    public Vector3 correct_position;
    public GameObject main_body;
    public int accur;
    public AudioSource sound_complite;
    public GameObject menu_pause;

    private bool compliteLvl = false;
    private bool object_moove = false;

    private Vector3 move_x = new Vector3(.1f, 0f, 0f);
    private Vector3 move_y = new Vector3(0f, .1f, 0f);
    private Vector3 move_z = new Vector3(0f, 0f, .1f);

    public bool debug = false; //DELETE!!

    void Update()
    {
        if (menu_pause.activeSelf)
            return ;
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

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
        if (debug) //Debug
            return;
        if (Input.GetKeyDown("z"))
        {
            if (!compliteLvl)
                compliteLvl = true;
            else
                compliteLvl = false;
        }
        if (!compliteLvl && Math.Abs(transform.eulerAngles[0] - correct_position[0]) < accur && Math.Abs(transform.eulerAngles[1] - correct_position[1]) < accur && Math.Abs(transform.eulerAngles[2] - correct_position[2]) < accur)
        {
            Debug.Log("You Win!2");
            sound_complite.Play();
            compliteLvl = true;
            main_body.GetComponent<ObjektMove>().ready = true;
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
        if (Input.GetKeyDown("i"))
        {
            Debug.Log("not main" + transform.eulerAngles + " " + correct_position);
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