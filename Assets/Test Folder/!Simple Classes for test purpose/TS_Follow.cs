using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TS_Follow : MonoBehaviour
{
    [SerializeField] private Transform Object;
    [SerializeField] private Transform target;
    Vector3 distance;
    // Start is called before the first frame update
    void Start()
    {
        distance = Object.position - target.position;
    }

    // Update is called once per frame
    void Update()
    {
        Object.position = distance + target.position;
    }
}
