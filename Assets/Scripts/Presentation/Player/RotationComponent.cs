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
        rotationLogic = new(rotationConfig);

        inputComponent = GetComponent<InputComponent>();
    }

    private void Update()
    {
        HandleRotation();
    }

    private void HandleRotation()
    {
        var horizontal = inputComponent.Move.x;

        var targetTurnSpeed = rotationLogic.GetTurnSpeed(inputComponent.IsRunning);

        currentTurnSpeed = Mathf.Lerp(currentTurnSpeed, targetTurnSpeed, 5f * Time.deltaTime);

        var rotation = horizontal * currentTurnSpeed * Time.deltaTime;

        transform.Rotate(0f, rotation, 0f);
    }
}