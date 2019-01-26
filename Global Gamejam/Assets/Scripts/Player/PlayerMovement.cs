using System;
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

    private bool canDoubleJump = true;
    private bool grounded
    {
        get
        {
            return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);
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
            myBody.velocity = velocity;
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
    }

    private void Jump()
    {
        if (grounded)
        {
            //set normal jump
            velocity = myBody.velocity;
            velocity.y = jumpSpeed;
            myBody.velocity = velocity;
        }
        else if (canDoubleJump)
        {
            //set second, mid-air jump with a minimum added velocity
            velocity = myBody.velocity;
            velocity.y = Mathf.Max(jumpSpeed, velocity.y + jumpSpeed);
            myBody.velocity = velocity;
            canDoubleJump = false;
        }
    }

    public void ApplyForce(Vector3 force) {
        myBody.AddForce(force);
    }
}
