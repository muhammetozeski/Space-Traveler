using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.HighDefinition;
using UnityEngine.UIElements;

public class PlayingInputController : MonoBehaviour
{
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private SpaceShipSettings spaceShipSettings;
    [SerializeField] private GameSettings gameSettings;

    [Tooltip("Input Action Map Name")]
    string PlayerMapName = "Player";
    [Tooltip("Pm = Player map. Input Action Name which is in the \"player\" input action map")]
    string PmMove = "Move", PmLook = "Look", PmFire = "Fire";

    InputAction Move, Look, Fire;
    InputActionMap PlayerMap;

    Vector2 MousePosition;

    [SerializeField] private  Vector2 lerpedRotation = new Vector2();

    [SerializeField] private RectTransform MouseTarget;
    [SerializeField] private RectTransform ShipsTarget;
    [SerializeField] private RectTransform Rope;

    Vector2 ShipPosition;
    Vector2 ShipRotatation = new Vector2();
    void Awake()
    {
      
        #region Assigns
        Move = playerInput.actions.FindAction(PlayerMapName + "/" + PmMove);
        Look = playerInput.actions.FindAction(PlayerMapName + "/" + PmLook);
        Fire = playerInput.actions.FindAction(PlayerMapName + "/" + PmFire);
        PlayerMap = playerInput.actions.FindActionMap(PlayerMapName);
        #endregion

        #region Assigns for "Move"
        Move.started += MoveOnStarted;
        Move.performed += MoveOnPerformed;
        Move.canceled += MoveOnCanceled;
        #endregion
        
        ShipPosition = Vector2.zero;
    }

    //debug purpose:
    [EButton] void activateMoving() { move = !move; object a = 5; a.GetType(); }
    [Tooltip("Debug purpose")]
    [SerializeField]  private  bool move = false;
    [Tooltip("Debug purpose")]
    [SerializeField] private float moveSpeed = 10;
    [Tooltip("Debug purpose")] public bool useXAxisOnRotate = false;

    private void Update()
    {
        MousePosition = Look.ReadValue<Vector2>() * spaceShipSettings.MouseSpeedMultiplier;
        RotateShip(MouseTarget.anchoredPosition / spaceShipSettings.TargetClamp);
        RotateTargets(MousePosition);
        if (move) //test purpose
            TransformShip(MouseTarget.anchoredPosition / spaceShipSettings.TargetClamp);
        if(Input.GetKeyDown(KeyCode.Space)) activateMoving(); //test purpose
    }
    private void RotateShip(Vector2 rotateDir)
    {
        if (rotateDir.magnitude < spaceShipSettings.TargetDeadZone) return;

        rotateDir *= spaceShipSettings.ShipZAxisAngularSpeed;
        ShipRotatation.x = Mathf.Clamp(-rotateDir.y, -spaceShipSettings.RotationClamp, spaceShipSettings.RotationClamp);
        ShipRotatation.y = Mathf.Clamp(-rotateDir.x, -spaceShipSettings.RotationClamp, spaceShipSettings.RotationClamp);

        if (!useXAxisOnRotate) ShipRotatation.x = 0;

        transform.rotation = Quaternion.Lerp(
            transform.rotation,
            Quaternion.Euler(MainTools.Vector2To3OnFlat(ShipRotatation)),
            spaceShipSettings.ShipRotationLerpSpeedMultiplier * Time.deltaTime
            );
    }

    private void RotateTargets(Vector2 rotateDir)
    {

        Vector2 ancPos = MouseTarget.anchoredPosition;
        float l = spaceShipSettings.TargetIconLerper;
        float _speed = spaceShipSettings.ShipRotationMultiplier / l * (l - 1) -
            (spaceShipSettings.ShipRotationMultiplier / l * (l - 1) / spaceShipSettings.TargetClamp) * ancPos.magnitude +
            spaceShipSettings.ShipRotationMultiplier / l * 1;

        Vector2 pos = ancPos + rotateDir * _speed; /* (*Time.deltaTime) ???*/
        //pos = Vector2.Lerp(pos, Vector2.ClampMagnitude(pos, 100), Time.deltaTime);
        pos = Vector2.ClampMagnitude(pos, spaceShipSettings.TargetClamp);
        MouseTarget.anchoredPosition = pos;


        float angle = MainTools.Vector2toAngle180(-MouseTarget.anchoredPosition);
        Rope.localEulerAngles = new Vector3(0, 0, angle);
        Rope.sizeDelta = new Vector2(Rope.sizeDelta.x, MouseTarget.anchoredPosition.magnitude);
    }

    /// <summary>
    /// Moves the player's ship
    /// </summary>
    /// <param name="dir">Direction</param>
    private void TransformShip(Vector2 dir)
    {
        if (dir.magnitude < spaceShipSettings.TargetDeadZone) return;

        ShipPosition += dir * spaceShipSettings.Speed;
        ShipPosition.x = Mathf.Clamp(ShipPosition.x,
            -gameSettings.RoadWeight, gameSettings.RoadWeight);
        ShipPosition.y = Mathf.Clamp(ShipPosition.y,
            -gameSettings.SpaceShipMaxTranslateHeight, gameSettings.RoadWeight);

        transform.position = new Vector3(ShipPosition.x,ShipPosition.y, 
            transform.forward.z * moveSpeed * Time.deltaTime);
    }

    private void MoveOnCanceled(InputAction.CallbackContext obj)
    {

    }

    private void MoveOnPerformed(InputAction.CallbackContext obj)
    {

    }

    private void MoveOnStarted(InputAction.CallbackContext obj)
    {

    }

    // are these really necessary? idk
    private void OnEnable()
    { PlayerMap.Enable(); }
    private void OnDisable()
    { PlayerMap.Disable(); }

    

}
