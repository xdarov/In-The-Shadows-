using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjektMove : MonoBehaviour
{
    private bool mouse1 = false;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            rb.constraints = RigidbodyConstraints.FreezeRotation;
            transform.Rotate(Vector3.right, Input.GetAxis("Mouse Y") * 20, Space.World);
            transform.Rotate(Vector3.down, Input.GetAxis("Mouse X") * 20, Space.World);
        }
        // if (Input.GetKey("q"))
        // {
        //     rb.AddTorque(-Vector3.left, ForceMode.VelocityChange);
        //     rb.AddTorque(-Vector3.up, ForceMode.VelocityChange);

        // }
    }
    void FixedUpdate() 
    {
    }
}
