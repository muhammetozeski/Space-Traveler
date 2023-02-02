using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class PlayingInputController : MonoBehaviour
{
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private SpaceShipSettings spaceShipSettings;
    [SerializeField] private GameSettings gameSettings;
    [SerializeField] private Rigidbody rb;

    [Tooltip("Input Action Map Name")]
    string PlayerMapName = "Player";
    [Tooltip("Pm = Player map. Input Action Name which is in the \"player\" input action map")]
    string PmMove = "Move", PmLook = "Look", PmFire = "Fire";

    InputAction Move, Look, Fire;
    InputActionMap PlayerMap;

    Vector2 MousePosition;

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

        //learning purpose:
        #region Assigns for "Move"
        Move.started += MoveOnStarted;
        Move.performed += MoveOnPerformed;
        Move.canceled += MoveOnCanceled;
        #endregion

        ShipPosition = Vector2.zero;

        //null checking:
        if(rb == null)
        {
            rb = GetComponent<Rigidbody>();
        }

        rb.maxDepenetrationVelocity = 30;
    }

    //debug purpose:
    [EButton] void TestButton() { }
    [Tooltip("Debug purpose")]
    [SerializeField] private bool move = false;
    [Tooltip("Debug purpose")]
    [SerializeField] private float moveSpeed = 10;
    [Tooltip("Debug purpose")] public bool useXAxisOnRotate = false;

    private void Update()
    {
        MousePosition = Look.ReadValue<Vector2>() * spaceShipSettings.MouseSpeedMultiplier;
        RotateTargets(MousePosition);
        RotateShip(MouseTarget.anchoredPosition);

        if (move) //test purpose
            MoveShip2d(MouseTarget.anchoredPosition / spaceShipSettings.TargetClamp);

        //ClampShipPosition();


        MoveShip3d(Move.ReadValue<Vector2>());
    }
    private void RotateShip(Vector2 rotateDir)
    {
        if (rotateDir.magnitude < spaceShipSettings.TargetDeadZone) rotateDir = Vector2.zero;
        
        else // for smoother animation, take out the dead zone
        {
            rotateDir -= Vector2.ClampMagnitude(rotateDir, spaceShipSettings.TargetDeadZone * 100);
        }
        rotateDir /= spaceShipSettings.TargetClamp;

        rotateDir.x *= -spaceShipSettings.ShipZAxisRotationClamp;
        rotateDir.y *= -spaceShipSettings.ShipXAxisRotationClamp;

        if (!useXAxisOnRotate) ShipRotatation.x = 0; // debug purpose

        transform.rotation = Quaternion.Lerp(
            transform.rotation,
            Quaternion.Euler(new Vector3(rotateDir.y,0,rotateDir.x)),
            spaceShipSettings.ShipAngularSpeed * Time.deltaTime
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

        pos = Vector2.ClampMagnitude(pos, spaceShipSettings.TargetClamp);
        MouseTarget.anchoredPosition = pos;


        float angle = MainTools.Vector2toAngle180(-MouseTarget.anchoredPosition);
        Rope.localEulerAngles = new Vector3(0, 0, angle);
        Rope.sizeDelta = new Vector2(Rope.sizeDelta.x, MouseTarget.anchoredPosition.magnitude);
    }

    /// <summary>
    /// Moves the player's ship to left - right and up - down
    /// </summary>
    private void MoveShip2d(Vector2 dir)
    {
        //TODO: don't move ship if the aim in "deadzone" circle

        Vector3 velocity = rb.velocity;
        //apply max speed:
        velocity = MainTools.Vector2to3( Vector2.ClampMagnitude( velocity, spaceShipSettings.Max2DSpeed), velocity.z);

        //keep it in borders:
        /*
        Vector2 border = new Vector2(gameSettings.RoadWeight, gameSettings.SpaceShipMaxTranslateHeight);
        if (!MainTools.IsPointInSquare((Vector2)transform.position, border, -border))
            velocity = MainTools.Vector2to3(Vector2.zero,velocity.z);
        /**/

        rb.velocity = velocity;

        rb.AddForce(dir * spaceShipSettings.Speed2d);
    }

    /// <summary>
    /// Moves the player's ship to front and back
    /// </summary>
    private void MoveShip3d(Vector2 dir)
    {
        //if (dir.magnitude == 0f) return;

        rb.AddForce(Vector3.forward * dir.y * spaceShipSettings.SpeedForward);
        Vector3 velocity = rb.velocity;
        //apply max speed
        velocity.z = Mathf.Clamp(velocity.z, 0, spaceShipSettings.Max3DSpeed);
        rb.velocity = velocity;
    }

    public void OnMove(InputAction.CallbackContext obj)
    {
        print("unity event");
    }
    private void MoveOnCanceled(InputAction.CallbackContext obj)
    {
        print("on canceled");
    }

    private void MoveOnPerformed(InputAction.CallbackContext obj)
    {
        print("on performed");
    }

    private void MoveOnStarted(InputAction.CallbackContext obj)
    {
        print("on started");
    }

    // are these really necessary? idk
    private void OnEnable()
    { PlayerMap.Enable(); }
    private void OnDisable()
    { PlayerMap.Disable(); }

    private void ClampShipPosition()
    {
        Vector3 shipPosition = transform.position;

        shipPosition.x = Mathf.Clamp(shipPosition.x,
            -gameSettings.RoadWeight, gameSettings.RoadWeight);

        shipPosition.y = Mathf.Clamp(shipPosition.y,
            -gameSettings.SpaceShipMaxTranslateHeight, gameSettings.SpaceShipMaxTranslateHeight);

        transform.position = shipPosition;
    }

}
