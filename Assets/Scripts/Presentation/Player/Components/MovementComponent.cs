using UnityEngine;

[RequireComponent(typeof(InputComponent), typeof(CharacterController))]
public class MovementComponent : MonoBehaviour
{
    [SerializeField] private MovementConfig movementConfig;

    private MovementLogic movementLogic;
    private InputComponent inputComponent;
    private CharacterController controller;

    public Vector3 Direction =>
        transform.forward * Mathf.Round(inputComponent.Direction.y);

    private void Start()
    {
        movementLogic = new(movementConfig.Mapper());

        inputComponent = GetComponent<InputComponent>();
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        var targetSpeed = movementLogic.GetSpeed(
            inputComponent.Direction.y, inputComponent.IsRunning);

        controller.Move(targetSpeed * Time.deltaTime * Direction);
    }
}