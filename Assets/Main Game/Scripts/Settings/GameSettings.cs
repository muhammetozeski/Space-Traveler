using UnityEngine;
[CreateAssetMenu(fileName = "Game Settings Data", menuName = "Single Scriptable Objects/Game Settings Data")]
public class GameSettings : ScriptableObject
{
    public float RoadWeight = 10;

    public float SpaceShipMaxTranslateHeight = 10;
}
