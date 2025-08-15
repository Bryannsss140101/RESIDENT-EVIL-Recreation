using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float maxSpeed = 1.5f;
    [SerializeField] private float minSpeed = 1f;
    [SerializeField] private float runSpeed = 3f;

    [Header("Rotation Settings")]
    [SerializeField] private float angularSpeed = 1.5f;

    [Header("Camera Settings")]
    [SerializeField] private CameraController cameraController;

    public bool IsRunning { get; private set; }

    private void Update()
    {
        Move();
        Rotate();
    }

    private void Move()
    {
        float vertical = Input.GetAxis("Vertical");
        float currentSpeed;

        IsRunning = Input.GetKey(KeyCode.LeftShift) && vertical > 0f;

        if (vertical < 0f)
            currentSpeed = minSpeed;
        else
            currentSpeed = IsRunning ? runSpeed : maxSpeed;

        Vector3 direction = transform.forward * vertical;
        transform.position += currentSpeed * Time.deltaTime * direction;
    }

    private void Rotate()
    {
        float angularVelocity = angularSpeed * Input.GetAxis("Horizontal");

        transform.Rotate(0f, angularVelocity, 0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("TriggerZone"))
        {
            var index = other.name[other.name.Length - 1] - '0';

            cameraController.FocusOnTarget(index);
        }
    }
}