using UnityEngine;
[CreateAssetMenu(fileName = "Meteorite Settings Data", menuName = "Scriptable Objects/Meteroite Settings Data")]
public class MeteoriteSettings : ScriptableObject
{
    [SerializeField] private float _AngularVelocity = 1;
    public float AngularVelocity { get { return _AngularVelocity; } private set { _AngularVelocity = value; } }


    [Range(0, 2)]
    [SerializeField] private float _MeteoriteSizeMultiplier = 1;
    public float MeteoriteSizeMultiplier { get => _MeteoriteSizeMultiplier; private set => _MeteoriteSizeMultiplier = value; }
}
