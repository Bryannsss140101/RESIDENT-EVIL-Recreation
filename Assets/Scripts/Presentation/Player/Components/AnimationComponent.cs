using UnityEngine;

[RequireComponent(typeof(Animator), typeof(InputComponent))]
public class AnimationComponent : MonoBehaviour
{
    private InputComponent inputComponent;
    private Animator animator;

    private static readonly int directionY = Animator.StringToHash("direction_y");
    private static readonly int directionX = Animator.StringToHash("direction_x");

    private void Start()
    {
        inputComponent = GetComponent<InputComponent>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        HandleAnimation();
    }

    private void HandleAnimation()
    {
        MovementAnimation();
        RotationAnimation();
    }

    private void MovementAnimation()
    {
        var direction = QuantizeDirection(inputComponent.Direction);

        animator.SetFloat(directionY, direction.y);
    }

    private void RotationAnimation()
    {
        var direction = QuantizeDirection(inputComponent.Direction);

        var horizontal =
                direction.y == 0f && inputComponent.IsRunning
                ? 0.5f
                : Mathf.Abs(direction.x);

        animator.SetFloat(directionX, horizontal);
    }

    private Vector2 QuantizeDirection(Vector2 input)
    {
        if (input == Vector2.zero)
            return Vector2.zero;

        float value = inputComponent.IsRunning ? 1f : 0.5f;

        return new Vector2(
            input.x != 0f ? Mathf.Sign(input.x) * value : 0f,
            input.y != 0f ? Mathf.Sign(input.y) * value : 0f
        );
    }
}