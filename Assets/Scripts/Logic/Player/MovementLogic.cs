using System;
using UnityEngine;

public class MovementLogic
{
    public float WalkSpeedMax { get; private set; }
    public float WalkSpeedMin { get; private set; }
    public float RunSpeedMax { get; private set; }

    public MovementLogic(MovementConfig movementConfig)
    {
        if (movementConfig == null)
            throw new ArgumentNullException(nameof(movementConfig));

        WalkSpeedMax = movementConfig.walkSpeedMax;
        WalkSpeedMin = movementConfig.walkSpeedMin;
        RunSpeedMax = movementConfig.runSpeedMax;
    }

    public float GetSpeed(float vertical, bool isRunning)
    {
        if (Mathf.Approximately(vertical, 0f))
            return 0f;

        if (vertical < 0f)
            return WalkSpeedMin;

        return isRunning ? RunSpeedMax : WalkSpeedMax;
    }
}