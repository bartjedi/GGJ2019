﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    private PlayerController controller;
    private AudioSource audioSource;

    [SerializeField]
    private AudioClip[] clips;

    private void Awake()
    {
        controller = GetComponent<PlayerController>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        animator.SetFloat("Horizontal", !controller.movement.grounded || !controller.input.allowMovement || !controller.input.allowInput ? 0 : controller.input.horizontal);
    }

    public void Jump()
    {
        animator.ResetTrigger("Land");
        animator.SetTrigger("Jump");
    }

    public void Land()
    {
        animator.SetTrigger("Land");
    }

    public void Shove() {
        animator.SetTrigger("Shove");
        int random = Random.Range(0, clips.Length);
        audioSource.PlayOneShot(clips[random]);
    }
}
