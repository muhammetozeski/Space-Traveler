using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO: this script is imported from my some old project and need some fixings for efficiency
 public class MAIN_TRANSPORTER_SCRIPT : MonoBehaviour
{
    /// <summary>
    ///  when the player came to teleportPosition in z axis, everything will go back teleportPosition in z axis.
    /// </summary>
    public float teleportPosition = 2000;

    [Tooltip("Everything that is added to scene by this script")]
    public List<GameObject> allStuffs = new List<GameObject>();

    public Transform player;

    [SerializeField] private maker Maker;

    void Update()
    {
        // if player went N steps on z axis, retract everything N steps
        if (player.position.z >= teleportPosition)
        {
            //player goes back up to teleportPosition
            player.position = new Vector3(player.position.x, player.position.y, player.position.z - teleportPosition);

            //allstuffs goes back to teleportPosition
            foreach (GameObject stuff in allStuffs)
            {
                stuff.transform.position = new Vector3(stuff.transform.position.x,
                    stuff.transform.position.y, stuff.transform.position.z - teleportPosition);
            }

            //end of road must change.
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
