using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class InputComponent : MonoBehaviour
{
    [SerializeField] private InputActionReference moveAction;
    [SerializeField] private InputActionReference runAction;

    public Vector2 Move { get; private set; }
    public bool IsRunning { get; private set; }

    private void OnEnable()
    {
        moveAction.action.Enable();
        runAction.action.Enable();
    }

    private void OnDisable()
    {
        moveAction.action.Disable();
        runAction.action.Disable();
    }

    private void Update()
    {
        Move = moveAction.action.ReadValue<Vector2>();
        IsRunning = runAction.action.ReadValue<float>() > 0.5f;
    }
}