using UnityEngine;

[RequireComponent(typeof(InputComponent), typeof(CharacterController))]
public class MovementComponent : MonoBehaviour
{
    [SerializeField] private MovementConfig movementConfig;

    private float walkSpeedMax;
    private float walkSpeedMin;
    private float runSpeedMax;
    private float walkTurnSpeed;
    private float runTurnSpeed;
    private float currentSpeed;
    private float currentTurnSpeed;

    private InputComponent inputComponent;
    private CharacterController controller;

    private void Awake()
    {
        walkSpeedMax = movementConfig.walkSpeedMax;
        walkSpeedMin = movementConfig.walkSpeedMin;
        runSpeedMax = movementConfig.runSpeedMax;
        walkTurnSpeed = movementConfig.walkTurnSpeed;
        runTurnSpeed = movementConfig.runTurnSpeed;

        inputComponent = GetComponent<InputComponent>();
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        HandleMovement();
        HandleRotation();
    }

    private void HandleMovement()
    {
        var vertical = inputComponent.Move.y;
        var horizontal = inputComponent.Move.x;
        var direction = transform.forward * vertical;

        var targetSpeed = CalculateTargetSpeed(vertical, horizontal);

        currentSpeed = Mathf.Lerp(currentSpeed, targetSpeed, 8f * Time.deltaTime);

        controller.Move(currentSpeed * Time.deltaTime * direction);
    }

    private void HandleRotation()
    {
        var horizontal = inputComponent.Move.x;

        var targetAngular = inputComponent.IsRunning ? runTurnSpeed : walkTurnSpeed;

        currentTurnSpeed = Mathf.Lerp(currentTurnSpeed, targetAngular, 5f * Time.deltaTime);

        var rotation = horizontal * currentTurnSpeed * Time.deltaTime;

        transform.Rotate(0f, rotation, 0f);
    }

    private float CalculateTargetSpeed(float vertical, float horizontal)
    {
        if (Mathf.Approximately(vertical, 0f) && Mathf.Approximately(horizontal, 0f))
            return 0f;

        if (vertical < 0f)
            return walkSpeedMin;

        return inputComponent.IsRunning ? runSpeedMax : walkSpeedMax;
    }
}