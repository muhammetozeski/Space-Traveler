using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TS_BorderTest : MonoBehaviour
{
    [SerializeField] float MaxSpeed = 10;
    [SerializeField] float speed = 10;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
            if (Input.GetKey(KeyCode.W))
            {
                rb.AddForce(Vector3.up * speed);
            }
            if (Input.GetKey(KeyCode.S))
            {
                rb.AddForce(Vector3.down * speed);
            }
    }
}
