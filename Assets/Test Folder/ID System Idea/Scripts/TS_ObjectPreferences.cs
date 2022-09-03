using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class TS_ObjectPreferences : MonoBehaviour
{
    [SerializeField] private int _ID;
    public int ID {get{ return _ID; }}

    [SerializeField] private TS_IDManager _IDManager;

    private void Awake()
    {
        _ID = _IDManager.GetNewID();

        _ID = gameObject.GetInstanceID();   

        print(gameObject.name + "'s ID is" + ID);
    }
}
