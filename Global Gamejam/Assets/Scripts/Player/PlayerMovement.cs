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
    private float outsideRight, outsideLeft;

	private Vector3 respawnLocation;

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
		respawnLocation = GameObject.Find("RespawnLocation").transform.position;
        outsideLeft = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, -Camera.main.transform.position.z)).x;
        outsideRight = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, -Camera.main.transform.position.z)).x;
    }

	private void OnEnable()
	{
		myBody.isKinematic = false;
	}

	private void OnDisable()
	{
		myBody.isKinematic = true;
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
            //myBody.velocity = velocity;
            transform.position = new Vector3(transform.position.x + velocity.x * Time.deltaTime, transform.position.y, transform.position.z);
        }
        if (grounded && jumpStartTime + 0.1f < Time.time) {
            controller.animations.Land();
        }
        transform.position = new Vector3(transform.position.x + velocity.x * Time.deltaTime, transform.position.y, transform.position.z);
    }

    private void Update()
    {
        velocity = myBody.velocity;
        if (controller.input.jump)
        {
            Jump();
        }

        if (!grounded && myBody.velocity.y < 3.75f)
            myBody.velocity = new Vector3(myBody.velocity.x, myBody.velocity.y - 0.15f, myBody.velocity.z);

        //read horizontal axis for horizontal movement
        velocity.x = controller.input.horizontal * moveSpeed;

        if (transform.position.y < -20f) {
			PlayerDies();
        }

        if (transform.position.x< outsideLeft - 2f) {
            transform.position = new Vector3(outsideRight + 1.5f, transform.position.y, transform.position.z);
        }
        if (transform.position.x > outsideRight + 2f)
        {
            transform.position = new Vector3(outsideLeft - 1.5f, transform.position.y, transform.position.z);
        }
    }
	
    public void Stun() {
        velocity.x = 0;
        myBody.velocity = velocity;
    }

	public void PlayerDies()
	{
		if(GameManagerScript.instance.gameState == GameManagerScript.States.Playing)
		{
			var pd = this.gameObject.GetComponent<PlayerDetails>();
			pd.Died();
			if (pd.playerHealth > 0) // Re-spawn
			{
				StartCoroutine(PlayerRespawn());
			
			}
		}
		else // not playing so always respawn
		{
			StartCoroutine(PlayerRespawn());
		}
	}

	private IEnumerator PlayerRespawn()
	{
		velocity.y = 0;
		myBody.velocity = velocity;
		this.gameObject.GetComponent<Rigidbody>().isKinematic = true;
        this.gameObject.GetComponent<Collider>().enabled = false;
		transform.position = new Vector3(respawnLocation.x, respawnLocation.y, transform.position.z);
        controller.input.allowInput = false;
		yield return new WaitForSeconds(2);
		this.gameObject.GetComponent<Rigidbody>().isKinematic = false;
        yield return new WaitForSeconds(0.1f);
        controller.input.allowInput = true;
        this.gameObject.GetComponent<Collider>().enabled = true;
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
        ResetVelocity();
        myBody.AddForce(force,ForceMode.Impulse);
    }

    public void ResetVelocity() {
        velocity = Vector3.zero;
        myBody.velocity = velocity;
    }

    public Vector3 GetVelocity() {
        return myBody.velocity;
    }
}
