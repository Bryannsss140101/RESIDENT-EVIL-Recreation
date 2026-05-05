using System;
using NUnit.Framework;

public class MovementLogicTest
{
    private MovementData movementData;
    private MovementLogic movementLogic;

    [SetUp]
    public void Setup()
    {
        movementData = new MovementData()
        {
            WalkSpeedMax = 3f,
            WalkSpeedMin = 1.5f,
            RunSpeedMax = 6f
        };

        movementLogic = new MovementLogic(movementData);
    }

    [Test]
    public void Constructor_InvalidData_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() =>
        {
            new MovementLogic(null);
        });
    }

    [Test]
    public void Constructor_ValidData_SetsValuesCorrectly()
    {
        var logic = new MovementLogic(movementData);

        Assert.AreEqual(movementData.WalkSpeedMax, logic.WalkSpeedMax);
        Assert.AreEqual(movementData.WalkSpeedMin, logic.WalkSpeedMin);
        Assert.AreEqual(movementData.RunSpeedMax, logic.RunSpeedMax);
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

        Assert.AreEqual(movementData.WalkSpeedMax, speed);
    }

    [Test]
    public void GetSpeed_WalkingBackward_ReturnWalkSpeedMin()
    {
        var speed = movementLogic.GetSpeed(-1f, false);

        Assert.AreEqual(movementData.WalkSpeedMin, speed);
    }

    [Test]
    public void GetSpeed_RunningForward_ReturnRunSpeedMax()
    {
        var speed = movementLogic.GetSpeed(1f, true);

        Assert.AreEqual(movementData.RunSpeedMax, speed);
    }

    [Test]
    public void GetSpeed_RunningBackward_ReturnWalkSpeedMin()
    {
        var speed = movementLogic.GetSpeed(-1f, true);

        Assert.AreEqual(movementData.WalkSpeedMin, speed);
    }
}