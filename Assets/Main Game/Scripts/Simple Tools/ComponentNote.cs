using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Use this to take some notes for game objects
/// </summary>
public class ComponentNote : MonoBehaviour
{
    [Multiline]
    public string Note = "TODO: ";
    [Multiline]
    public string[] MultipleNotes;
}
