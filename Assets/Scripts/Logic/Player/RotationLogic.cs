using System;

public class RotationLogic
{
    public float WalkTurnSpeed { get; private set; }
    public float RunTurnSpeed { get; private set; }

    public RotationLogic(RotationData rotationData)
    {
        if (rotationData == null)
            throw new ArgumentNullException();

        WalkTurnSpeed = rotationData.WalkTurnSpeed;
        RunTurnSpeed = rotationData.RunTurnSpeed;
    }

    public float GetTurnSpeed(bool isRunning)
    {
        return isRunning ? RunTurnSpeed : WalkTurnSpeed;
    }
}