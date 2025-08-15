using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private PlayerMovement playerMovement;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));
        animator.SetFloat("Vertical", Input.GetAxis("Vertical"));
        animator.SetBool("Run", playerMovement.IsRunning);
    }
}