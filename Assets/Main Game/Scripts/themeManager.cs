using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class themeManager : MonoBehaviour
{
    [SerializeField] public Properties[] themeEngine;
    void Start()
    {
        
    }
    /*
    public void SetValue(int index, SubClass subClass)
    {

        // Perform any validation checks here.
        myArray[index] = subClass;
    }
    public SubClass GetValue(int index)
    {
        // Perform any validation checks here.
        return myArray[index];
    }*/
}
[System.Serializable]
public class Properties
{
    public string themeTitle;

    [Tooltip("the roads to be assigned")]
    public List<GameObject> themeObjectsList = new List<GameObject>();

    [Tooltip("the roads will assign according to this ratios")]
    public int[] ratioOfObjects;

    [Tooltip("the following above are will be signed randomly but the following below will be signed immediately.\naboves are roads, belows are assistants, like raining system etc.")]
    public List<GameObject> signedImmediately = new List<GameObject>();

    [Tooltip("enter the objects to be signed immediately which location should be in")]
    public List<Vector3> signedImmediatelyLocations = new List<Vector3>();

}
