﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody myBody;
    [SerializeField]
    private float moveSpeed = 2.0f;
    [SerializeField]
    private float jumpSpeed = 3.0f, doubleJumpSpeed = 3.0f;

    private PlayerController controller;

    private Vector3 velocity = new Vector3();

    private float distToGround;

    [System.NonSerialized]
    public float jumpStartTime = float.MinValue;

    private bool canDoubleJump = true, jumping = false;

    public bool grounded
    {
        get
        {
            int layerMask = 1 << 9;
            return Physics.Raycast(transform.position, Vector3.down, distToGround + 0.1f, layerMask);
        }
    }

    private void Awake()
    {
        controller = GetComponent<PlayerController>();
        myBody = GetComponent<Rigidbody>();
        //calculate distance to glound based on collider
        distToGround = GetComponent<Collider>().bounds.extents.y;
    }

    private void FixedUpdate()
    {
        if (!canDoubleJump)
        {
            //only reset double jumping if the player is grounded
            canDoubleJump = grounded;
        }

        //apply velocity updates in the FixedUpdate method for better physics
        if (controller.input.allowMovement && controller.input.allowInput) {
            if (velocity.x > 0.0f) {
                transform.eulerAngles = new Vector3(0, 0, 0);
            }
            else if (velocity.x < 0.0f) {
                transform.eulerAngles = new Vector3(0, 180, 0);
            }
            myBody.velocity = velocity;
        }
        if (grounded && jumpStartTime + 0.1f < Time.time) {
            controller.animations.Land();
        }
    }

    private void Update()
    {
        velocity = myBody.velocity;
        if (controller.input.jump)
        {
            Jump();
        }
        //read horizontal axis for horizontal movement
        velocity.x = controller.input.horizontal * moveSpeed;

        if (transform.position.y < -20f) {
            velocity.y = 0;
            myBody.velocity = velocity;
            transform.position = new Vector3(transform.position.x, 20f, transform.position.z);
        }
    }

    private void Jump()
    {
        if (grounded)
        {
            //set normal jump
            velocity = myBody.velocity;
            velocity.y = jumpSpeed;
            myBody.velocity = velocity;
            controller.animations.Jump();
            jumpStartTime = Time.time;
        }
        else if (canDoubleJump)
        {
            //set second, mid-air jump with a minimum added velocity
            velocity = myBody.velocity;
            velocity.y = jumpSpeed;
            myBody.velocity = velocity;
            canDoubleJump = false;
            controller.animations.Jump();
        }
    }

    public void ApplyForce(Vector3 force) {
        myBody.AddForce(force);
    }

    public void ResetVelocity() {
        velocity = Vector3.zero;
        myBody.velocity = velocity;
    }
}
