using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Components")]
    [SerializeField] private float speed;
    [SerializeField] private float minSpeed;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float angularSpeed;
    private bool onRunning;

    [Header("Animation Components")]
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        HandleMovement();
        HandleRotation();
    }

    private void HandleMovement()
    {
        Vector3 direction = transform.forward * Input.GetAxis("Vertical");
        float currentSpeed = direction.z < 0 ? minSpeed : speed;

        transform.position += currentSpeed * Time.deltaTime * direction;

        animator.SetFloat("Vertical", direction.z);

        //velocity += speed * Time.deltaTime * (vertical * transform.forward);

        //transform.position += velocity;

        /*float vertical = Input.GetAxis("Vertical");
        float currentSpeed;

        if (Input.GetKey(KeyCode.V))
            currentSpeed = maxSpeed;
        else
            currentSpeed = (vertical < 0) ? 1 : speed;

        velocity = currentSpeed * Time.deltaTime * (vertical * transform.forward);
        transform.position += velocity;*/
    }

    private void HandleRotation()
    {
        /*
        float horizontal = Input.GetAxis("Horizontal");

        float angularVelocity = angularSpeed * horizontal;
        transform.Rotate(0f, angularVelocity, 0f);*/
    }

    void OnDrawGizmos()
    {
        /*
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.forward * 2f);
        */
    }
}