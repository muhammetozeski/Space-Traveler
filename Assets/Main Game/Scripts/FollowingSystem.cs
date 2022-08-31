using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingSystem : MonoBehaviour
{
    public Transform playerPosition;
    public Transform cameraPosition;
    public Vector3 distance;

    void Start()
    {
        distance = new Vector3(cameraPosition.position.x - playerPosition.position.x, cameraPosition.position.y - playerPosition.position.y,
            cameraPosition.position.z - playerPosition.position.z);
    }
    // Update is called once per frame
    void Update()
    {
        cameraPosition.position = playerPosition.position + distance;
    }
}