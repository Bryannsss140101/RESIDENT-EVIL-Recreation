using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class InputComponent : MonoBehaviour
{
    [SerializeField] private InputActionReference moveAction;
    [SerializeField] private InputActionReference runAction;

    public Vector2 Move { get; set; }
    public bool IsRunning { get; set; }
    public bool CanProcessInput { get; set; } = true;

    public void ResetInput()
    {
        Move = Vector2.zero;
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
            Move = moveAction.action.ReadValue<Vector2>();

        if (runAction != null)
            IsRunning = runAction.action.ReadValue<float>() > 0.5f;
    }
}