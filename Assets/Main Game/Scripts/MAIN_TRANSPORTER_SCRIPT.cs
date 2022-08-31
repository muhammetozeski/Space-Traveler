using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MAIN_TRANSPORTER_SCRIPT : MonoBehaviour
{
    /// <summary>
    /// this is allows us to use "maker.cs" varaibles or funcitons.
    /// </summary>
    maker Maker;
    /// <summary>
    ///  when the player came to teleportPosition in z axis, everything will go back teleportPosition in z axis.
    /// </summary>
    public float teleportPosition = 2000;

    /// <summary>
    ///  i wanna add every object that in scene to this list below
    /// </summary>
    public List<GameObject> allStuffs = new List<GameObject>();

    /// <summary>
    /// to know player's position in this way we can change the all stuffs position when the player came to teleportPosition.
    /// </summary>
    public Transform player;

    void Start()
    {
        //this is allows us to use "maker.cs" varaibles or funcitons.
        Maker = (maker)FindObjectOfType(typeof(maker));
    }
    void Update()
    {
        // if player went N steps on z axis, retract everything N steps
        if (player.position.z >= teleportPosition)
        {
            //player goes back up to teleportPosition
            player.position = new Vector3(player.position.x, player.position.y, player.position.z - teleportPosition);

            //allstuffs goes back up to teleportPosition
            foreach (GameObject stuff in allStuffs)
            {
                stuff.GetComponent<Transform>().position = new Vector3(stuff.GetComponent<Transform>().position.x,
                    stuff.GetComponent<Transform>().position.y, stuff.GetComponent<Transform>().position.z - teleportPosition);
            }

            //end of road naturally must change.
            Maker.endOfRoad -= teleportPosition;
        }

    }
    /// <summary>
    /// Remove From List = rfl
    /// This function allows us to remove any game object from allStuffs List. this function is created for not write long codes.
    /// </summary>
    public void rfl(GameObject object_to_be_removed)
    {
        allStuffs.RemoveAt(allStuffs.IndexOf(object_to_be_removed));
    }
}
