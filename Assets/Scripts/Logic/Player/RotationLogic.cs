public class RotationLogic
{
    public float WalkTurnSpeed { get; private set; }
    public float RunTurnSpeed { get; private set; }

    public RotationLogic(RotationConfig rotationConfig)
    {
        WalkTurnSpeed = rotationConfig.walkTurnSpeed;
        RunTurnSpeed = rotationConfig.runTurnSpeed;
    }

    public float GetTurnSpeed(bool isRunning)
    {
        return isRunning ? RunTurnSpeed : WalkTurnSpeed;
    }
}