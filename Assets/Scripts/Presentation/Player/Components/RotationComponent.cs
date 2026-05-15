using UnityEngine;

[RequireComponent(typeof(InputComponent))]
public class RotationComponent : MonoBehaviour
{
    [SerializeField] protected RotationConfig rotationConfig;
    private RotationLogic rotationLogic;

    private InputComponent inputComponent;

    public Vector3 Direction =>
        transform.up * Mathf.Round(inputComponent.Direction.x);

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
        var targetTurnSpeed = rotationLogic.GetTurnSpeed(
            inputComponent.Direction.y, inputComponent.IsRunning);

        transform.Rotate(targetTurnSpeed * Time.deltaTime * Direction);
    }
}