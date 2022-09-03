using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "IDManager", menuName = "Test Purpose Scriptable Objects/ID Manager")]
class TS_IDManager : ScriptableObject
{
    [SerializeField] private string _ObjectName;
    public string ObjectName { get { return _ObjectName; } private set { _ObjectName = value; } }

    int IDCounter = 0;

    public int GetNewID() { return ++IDCounter; }
}
