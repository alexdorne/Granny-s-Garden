using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : Singleton<InputManager> 
{
    PlayerControls playerControls; 
    PlayerInput playerInput; 

    public Vector2 MovementInputVector { get; private set; }

    public Vector2 CameraInputVector { get; private set; }

    private void Awake()
    {
        playerControls = new PlayerControls();
        playerControls.PlayerMovement.Movement.performed += Movement_Performed; 
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls?.Disable();
    }

    private void Update()
    {
        MovementInputVector = playerControls.PlayerMovement.Movement.ReadValue<Vector2>();
        CameraInputVector = playerControls.CameraMovement.CameraRotate.ReadValue<Vector2>();
        
    }

    private void Movement_Performed(InputAction.CallbackContext context)
    {
        //Debug.Log(context); 
    }
}
