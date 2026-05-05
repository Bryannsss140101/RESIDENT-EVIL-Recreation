using UnityEngine;

[CreateAssetMenu(fileName = "MovementConfig", menuName = "Configurations/MovementConfig")]
public class MovementConfig : ScriptableObject, IConfig<MovementData>
{
    public float walkSpeedMax = 3f;
    public float walkSpeedMin = 1.5f;
    public float runSpeedMax = 6f;

    public MovementData Mapper()
    {
        return new MovementData()
        {
            WalkSpeedMax = walkSpeedMax,
            WalkSpeedMin = walkSpeedMin,
            RunSpeedMax = runSpeedMax
        };
    }
}