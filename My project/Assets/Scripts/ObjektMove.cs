using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ObjektMove : MonoBehaviour
{
    private bool compliteLvl = false;
    public Vector3 correct_position;

    private Vector3 move_x = new Vector3(.1f, 0f, 0f);
    private Vector3 move_y = new Vector3(0f, .1f, 0f);
    private Vector3 move_z = new Vector3(0f, 0f, .1f);

    public bool debug = false; //DELETE!!

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
        if (!compliteLvl && Math.Abs(transform.eulerAngles[0] - correct_position[0]) < 30 && Math.Abs(transform.eulerAngles[1] - correct_position[1]) < 30 && Math.Abs(transform.eulerAngles[2] - correct_position[2]) < 30)
        {
            Debug.Log("You Win!");
            compliteLvl = true;
        }
        if (compliteLvl)
        {
            if (transform.eulerAngles[0] < correct_position[0])
                transform.eulerAngles += move_x;
            else
                transform.eulerAngles -= move_x;
            if (transform.eulerAngles[1] < correct_position[1])
                transform.eulerAngles += move_y;
            else
                transform.eulerAngles -= move_y;
            if (transform.eulerAngles[2] < correct_position[2])
                transform.eulerAngles += move_z;
            else 
                transform.eulerAngles -= move_z;
        }
        if (Input.GetKeyDown("i"))
        {
            Debug.Log(transform.eulerAngles + " " + correct_position);
        }
    }
}


