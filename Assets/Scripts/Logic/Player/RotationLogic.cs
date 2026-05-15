using System;
using UnityEngine;

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

    public float GetTurnSpeed(float vertical, bool isRunning)
    {
        if (Mathf.Approximately(vertical, 0f))
            return WalkTurnSpeed;

        if (vertical < 0f)
            return WalkTurnSpeed;

        return isRunning ? RunTurnSpeed : WalkTurnSpeed;
    }
}