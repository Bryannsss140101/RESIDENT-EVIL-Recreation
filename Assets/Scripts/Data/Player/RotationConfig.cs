using UnityEngine;

[CreateAssetMenu(fileName = "RotationConfig", menuName = "Configurations/RotationConfig")]
public class RotationConfig : ScriptableObject
{
    public float walkTurnSpeed = 120f;
    public float runTurnSpeed = 80f;
}