using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform[] targets;

    public void FocusOnTarget(int index)
    {
        if (index < 0 || index >= targets.Length) return;

        Transform target = targets[index];
        transform.position = target.position;
        transform.rotation = target.rotation;
    }
}