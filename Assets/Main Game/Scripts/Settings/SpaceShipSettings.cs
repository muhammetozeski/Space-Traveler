using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.Rendering;
using UnityEngine;

[CreateAssetMenu(fileName = "Space Ship Settings Data", menuName = "Single Scriptable Objects/Game Settings Data/Player Settings/Space Ship Settings Data")]
public class SpaceShipSettings : ScriptableObject
{
    [Header("Ship Speed Settings")]

    [Tooltip("Moving Speed of Player's ship")]
    [SerializeField] private float _Speed;
    public float Speed { get { return _Speed; } private set { _Speed = value; } }

    [Header("Ship Rotation Settings")]

    [Tooltip("Z axis speed of rotation of Player's ship")]
    [SerializeField] private float _ShipZAxisRotationClamp;
    public float ShipZAxisRotationClamp { get { return _ShipZAxisRotationClamp; } private set { _ShipZAxisRotationClamp = value; } }

    [Tooltip("X axis speed of rotation of Player's ship")]
    [SerializeField] private float _ShipXAxisRotationClamp;
    public float ShipXAxisRotationClamp { get { return _ShipXAxisRotationClamp; } private set { _ShipXAxisRotationClamp = value; } }

    [Tooltip("Angular Lerping Speed of Player's ship")]
    public float ShipAngularSpeed = 1f;
    
    [Tooltip("Rotation clamp of Player's ship")]
    [SerializeField] private float _RotationClamp = 10f;
    public float RotationClamp {get{ return _RotationClamp; } private set { _RotationClamp = value; } }
    
    [Header("Target Speed Settings")]

    [Tooltip("Speed of The Target icon that is on the canvas, it effects angular speed of the player's ship")]
    public float ShipRotationMultiplier = 10f;

    [Tooltip("Circle border area for target icon")]
    [SerializeField] private float _TargetClamp = 100f;
    public float TargetClamp { get { return _TargetClamp; } private set { _TargetClamp = value; } }

    [Tooltip("Lerp rate for target icon (keep it big)")]
    [Min(2)]
    [SerializeField] private float _TargetIconLerper = 10f;
    public float TargetIconLerper { get { return _TargetIconLerper; } private set { _TargetIconLerper = value < 2 ? 2 : value; } }

    
    [SerializeField] private float _TargetDeadZone = 10f;
    public float TargetDeadZone { get { return _TargetDeadZone; } private set { _TargetDeadZone = value; } }

    [Space]
    [Tooltip("TODO: move this to \"general settings\" ")]
    public float MouseSpeedMultiplier = 10f;
}
