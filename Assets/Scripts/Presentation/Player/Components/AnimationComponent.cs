using System;
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
        var horizontal = QuantizeDirection(inputComponent.Direction).y;

        animator.SetFloat(directionY, horizontal);
    }

    private void RotationAnimation()
    {
        var vertical = QuantizeDirection(inputComponent.Direction).x;

        if (inputComponent.Direction.y == 0f)
            animator.SetFloat(directionX, Mathf.Abs(vertical));
    }

    private Vector2 QuantizeDirection(Vector2 input)
    {
        if (input == Vector2.zero)
            return Vector2.zero;

        var value = inputComponent.IsRunning ? 1f : 0.5f;

        return new Vector2(
            input.x != 0f ? Mathf.Sign(input.x) * value : 0f,
            input.y != 0f ? Mathf.Sign(input.y) * value : 0f
        );
    }
}