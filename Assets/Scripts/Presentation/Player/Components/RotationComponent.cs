using UnityEngine;

[RequireComponent(typeof(InputComponent))]
public class RotationComponent : MonoBehaviour
{
    [SerializeField] protected RotationConfig rotationConfig;
    private RotationLogic rotationLogic;

    private InputComponent inputComponent;

    private float currentTurnSpeed;

    private void Awake()
    {
        rotationLogic = new(rotationConfig.Mapper());

        inputComponent = GetComponent<InputComponent>();
    }

    private void Update()
    {
        HandleRotation(inputComponent.Move.x, inputComponent.IsRunning);
    }

    private void HandleRotation(float horizontal, bool isRunning)
    {
        var targetTurnSpeed = rotationLogic.GetTurnSpeed(isRunning);

        currentTurnSpeed = Mathf.Lerp(currentTurnSpeed, targetTurnSpeed, 5f * Time.deltaTime);

        var rotation = horizontal * currentTurnSpeed * Time.deltaTime;

        transform.Rotate(0f, rotation, 0f);
    }
}