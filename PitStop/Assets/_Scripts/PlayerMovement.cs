using UnityEditor.Timeline;
using UnityEngine;

/// <summary>
/// Controls player movemnent
/// 
/// Ruben Sanchez
/// 4/14/18
/// </summary>

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed = 10;

    [SerializeField]
    private float turnSpeed = 100;

    private CharacterController characterController;
    private Animator animator;

    private void Awake()
    {
        if(GetComponent<CharacterController>())
            characterController = GetComponent<CharacterController>();

        else
            Debug.LogError("Character Controller not found.");

        if (GetComponentInChildren<Animator>())
            animator = GetComponentInChildren<Animator>();

        else
            Debug.LogError("Animator not found");
    }

    void Update()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");

        if(horizontal != 0)
            transform.Rotate(Vector3.up, horizontal * turnSpeed);

        if (vertical != 0)
            characterController.SimpleMove(transform.forward * speed * vertical);

        animator.SetFloat("Speed", vertical);
    }
}
