using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermanager : MonoBehaviour
{
    public float tspeed;
    public float speed;
    public float jumpSpeed;
    public float downSpeed;
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("s"))
        {
            rb.AddForce(0, 0, -speed * Time.deltaTime, ForceMode.VelocityChange);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            rb.velocity = new Vector3(0, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpSpeed, rb.velocity.z);
        }

        if (Input.GetKey("k"))
        {
            rb.velocity = new Vector3(rb.velocity.x, -jumpSpeed, rb.velocity.z);
        }
        if (Input.GetKey("w"))
        {
            //rb.velocity = new Vector3(0, 0, speed);
            rb.AddForce(0, 0, speed * Time.deltaTime, ForceMode.VelocityChange);
        }
        if (Input.GetKey("d"))
        {
            rb.AddForce(tspeed * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        if (Input.GetKey("a"))
        {
            rb.AddForce(-tspeed * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }


    }
}
