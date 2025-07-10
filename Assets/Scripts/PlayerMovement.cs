using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float angularSpeed;

    private void Update()
    {
        HandleMovement();
        HandleRotation();
    }

    private void HandleMovement()
    {
        float vertical = Input.GetAxis("Vertical");
        float currentSpeed = (vertical < 0) ? 1 : speed;

        Vector3 velocity = currentSpeed * Time.deltaTime * (vertical * transform.forward);
        transform.position += velocity;
    }

    private void HandleRotation()
    {
        float horizontal = Input.GetAxis("Horizontal");

        float angularVelocity = angularSpeed * horizontal;
        transform.Rotate(0f, angularVelocity, 0f);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.forward * 2f);
    }
}