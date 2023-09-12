using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// test purpose
/// </summary>
public class TS_opsts : MonoBehaviour
{
    [SerializeField] ObjectPoolingSystem poolingSystem;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Transform tr = poolingSystem.GetPool().transform;
        tr.gameObject.SetActive(true);
        tr.position = transform.position;
    }
}
