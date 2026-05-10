using UnityEngine;

[RequireComponent(typeof(InputComponent))]
public class RotationComponent : MonoBehaviour
{
    [SerializeField] protected RotationConfig rotationConfig;
    private RotationLogic rotationLogic;

    private InputComponent inputComponent;

    private void Awake()
    {
        rotationLogic = new(rotationConfig.Mapper());

        inputComponent = GetComponent<InputComponent>();
    }

    private void Update()
    {
        HandleRotation();
    }

    private void HandleRotation()
    {
        var direction = inputComponent.Direction;

        if (direction.y < 0f)
            return;

        var useWalkTurnSpeed = direction == Vector2.zero && inputComponent.IsRunning;

        var turnSpeed = rotationLogic.GetTurnSpeed(
            !useWalkTurnSpeed && inputComponent.IsRunning
        );

        var rotation = direction.x * turnSpeed * Time.deltaTime;

        transform.Rotate(0f, rotation, 0f);
    }
}