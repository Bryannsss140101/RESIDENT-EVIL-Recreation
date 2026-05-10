using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class InputComponent : MonoBehaviour
{
    [SerializeField] private InputActionReference moveAction;
    [SerializeField] private InputActionReference runAction;

    public Vector2 Direction { get; set; }
    public bool IsRunning { get; set; }
    public bool CanProcessInput { get; set; } = true;

    public void ResetInput()
    {
        Direction = Vector2.zero;
        IsRunning = false;
    }

    private void OnEnable()
    {
        if (moveAction != null) moveAction.action.Enable();
        if (runAction != null) runAction.action.Enable();
    }

    private void OnDisable()
    {
        if (moveAction != null) moveAction.action.Disable();
        if (runAction != null) runAction.action.Disable();
    }

    private void Update()
    {
        if (!CanProcessInput)
            return;

        if (moveAction != null)
            Direction = moveAction.action.ReadValue<Vector2>();

        if (runAction != null)
            IsRunning = runAction.action.ReadValue<float>() > 0.5f;
    }
}