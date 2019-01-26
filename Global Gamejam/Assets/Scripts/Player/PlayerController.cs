﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public PlayerMovement movement { get; private set; }
    public PlayerInput input { get; private set; }
    public PlayerCombat combat { get; private set; }
    public PlayerHealth health { get; private set; }

	private void Awake()
	{
        movement = GetComponent<PlayerMovement>();
        input = GetComponent<PlayerInput>();
        combat = GetComponent<PlayerCombat>();
        health = GetComponent<PlayerHealth>();
	}
}