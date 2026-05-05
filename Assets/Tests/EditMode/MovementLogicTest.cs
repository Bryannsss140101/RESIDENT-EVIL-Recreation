using System;
using NUnit.Framework;
using UnityEngine;

public class MovementLogicTest
{
    private MovementConfig movementConfig;
    private MovementLogic movementLogic;

    [SetUp]
    public void Setup()
    {
        movementConfig = ScriptableObject.CreateInstance<MovementConfig>();
        movementConfig.walkSpeedMax = 3f;
        movementConfig.walkSpeedMin = 1.5f;
        movementConfig.runSpeedMax = 6f;

        movementLogic = new MovementLogic(movementConfig);
    }

    [Test]
    public void Constructor_InvalidConfig_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() =>
        {
            new MovementLogic(null);
        });
    }

    [Test]
    public void Constructor_ValidConfig_SetsValuesCorrectly()
    {
        var logic = new MovementLogic(movementConfig);

        Assert.AreEqual(movementConfig.walkSpeedMax, logic.WalkSpeedMax);
        Assert.AreEqual(movementConfig.walkSpeedMin, logic.WalkSpeedMin);
        Assert.AreEqual(movementConfig.runSpeedMax, logic.RunSpeedMax);
    }

    [Test]
    public void GetSpeed_NoInput_ReturnZero()
    {
        var speed = movementLogic.GetSpeed(0f, false);

        Assert.AreEqual(0f, speed);
    }

    [Test]
    public void GetSpeed_WalkingForward_ReturnWalkSpeedMax()
    {
        var speed = movementLogic.GetSpeed(1f, false);

        Assert.AreEqual(movementConfig.walkSpeedMax, speed);
    }

    [Test]
    public void GetSpeed_WalkingBackward_ReturnWalkSpeedMin()
    {
        var speed = movementLogic.GetSpeed(-1f, false);

        Assert.AreEqual(movementConfig.walkSpeedMin, speed);
    }

    [Test]
    public void GetSpeed_RunningForward_ReturnRunSpeedMax()
    {
        var speed = movementLogic.GetSpeed(1f, true);

        Assert.AreEqual(movementConfig.runSpeedMax, speed);
    }

    [Test]
    public void GetSpeed_RunningBackward_ReturnWalkSpeedMin()
    {
        var speed = movementLogic.GetSpeed(-1f, true);

        Assert.AreEqual(movementConfig.walkSpeedMin, speed);
    }
}