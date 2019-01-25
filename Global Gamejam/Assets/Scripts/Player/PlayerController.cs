using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerInput), typeof(PlayerMovement))]
public class PlayerController : MonoBehaviour
{
    public PlayerMovement movement { get; private set; }
    public PlayerInput input { get; private set; }

	private void Awake()
	{
        movement = GetComponent<PlayerMovement>();
        input = GetComponent<PlayerInput>();
	}
}
