using UnityEngine;

[CreateAssetMenu(fileName = "MovementConfig", menuName = "Configurations/MovementConfig")]
public class MovementConfig : ScriptableObject
{
    public float walkSpeedMax = 3f;
    public float walkSpeedMin = 1.5f;
    public float runSpeedMax = 6f;
}