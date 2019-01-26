using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    private PlayerController controller;

    private void Awake()
    {
        controller = GetComponent<PlayerController>();
    }

    private void Update()
    {
        animator.SetFloat("Horizontal", !controller.movement.grounded ? 0 : controller.input.horizontal);
    }

    public void Jump()
    {
        Debug.Log("jump");
        animator.SetBool("Jump", true);
    }

    public void Land()
    {
        animator.SetBool("Jump", false);
    }
}
