using NUnit.Framework;
using UnityEngine;

public class MovementComponentTest
{
    private GameObject gameObject;
    private MovementComponent movementComponent;
    private InputComponent inputComponent;

    [SetUp]
    public void SetUp()
    {
        gameObject = new GameObject("Player-Test");

        movementComponent = gameObject.AddComponent<MovementComponent>();
        inputComponent = gameObject.AddComponent<InputComponent>();

        inputComponent.CanProcessInput = false;
    }

    [TearDown]
    public void TearDown()
    {
        Object.DestroyImmediate(gameObject);
    }
}