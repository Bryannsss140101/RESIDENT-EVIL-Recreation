using System;
using NUnit.Framework;

public class RotationLogicTest
{
    private RotationData rotationData;
    private RotationLogic rotationLogic;

    [SetUp]
    public void Setup()
    {
        rotationData = new RotationData()
        {
            WalkTurnSpeed = 120f,
            RunTurnSpeed = 80f
        };

        rotationLogic = new RotationLogic(rotationData);
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
        var logic = new RotationLogic(rotationData);

        Assert.AreEqual(rotationData.WalkTurnSpeed, logic.WalkTurnSpeed);
        Assert.AreEqual(rotationData.RunTurnSpeed, logic.RunTurnSpeed);
    }

    [Test]
    public void GetTurnSpeed_NoInput_ReturnZero()
    {
        var speed = rotationLogic.GetTurnSpeed(0f, false);

        Assert.AreEqual(0f, speed);
    }

    [Test]
    public void GetTurnSpeed_WalkingBackward_ReturnWalkTurnSpeed()
    {
        var speed = rotationLogic.GetTurnSpeed(-1f, false);

        Assert.AreEqual(rotationData.WalkTurnSpeed, speed);
    }

    [Test]
    public void GetTurnSpeed_Walking_ReturnWalkTurnSpeed()
    {
        var speed = rotationLogic.GetTurnSpeed(1f, false);

        Assert.AreEqual(rotationData.WalkTurnSpeed, speed);
    }

    [Test]
    public void GetTurnSpeed_Running_ReturnRunTurnSpeed()
    {
        var speed = rotationLogic.GetTurnSpeed(1f, true);

        Assert.AreEqual(rotationData.RunTurnSpeed, speed);
    }
}