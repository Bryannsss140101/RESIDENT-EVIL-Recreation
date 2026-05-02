using UnityEngine;

[CreateAssetMenu(fileName = "MovementConfig", menuName = "Configurations/MovementConfig")]
public class MovementConfig : ScriptableObject
{
    public float walkSpeedMax = 3f;

    public float walkSpeedMin = 1.5f;

    public float runSpeedMax = 6f;

    public float walkTurnSpeed = 120f;

    public float runTurnSpeed = 80f;
}