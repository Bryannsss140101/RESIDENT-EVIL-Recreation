using UnityEngine;

[RequireComponent(typeof(InputComponent), typeof(CharacterController))]
public class MovementComponent : MonoBehaviour
{
    [SerializeField] private MovementConfig movementConfig;
    private MovementLogic movementLogic;

    private InputComponent inputComponent;
    private CharacterController controller;

    private float currentSpeed;

    private void Start()
    {
        movementLogic = new(movementConfig.Mapper());

        inputComponent = GetComponent<InputComponent>();
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        HandleMovement(inputComponent.Move.y, inputComponent.IsRunning);
    }

    private void HandleMovement(float vertical, bool isRunning)
    {
        var direction = transform.forward * vertical;

        var targetSpeed = movementLogic.GetSpeed(vertical, isRunning);

        currentSpeed = Mathf.Lerp(currentSpeed, targetSpeed, 8f * Time.deltaTime);

        controller.Move(currentSpeed * Time.deltaTime * direction);
    }
}