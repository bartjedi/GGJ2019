using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public PlayerMovement movement { get; private set; }
    public PlayerInput input { get; private set; }
    public PlayerCombat combat { get; private set; }
    public PlayerDetails details { get; private set; }
    public PlayerAnimations animations { get; private set; }

	private void Awake()
	{
        movement = GetComponent<PlayerMovement>();
        input = GetComponent<PlayerInput>();
        combat = GetComponent<PlayerCombat>();
        details = GetComponent<PlayerDetails>();
        animations = GetComponent<PlayerAnimations>();

		movement.enabled = false;
		input.enabled = false;
		combat.enabled = false;
		details.enabled = false;
		animations.enabled = false;
	}

	public void Entry()
	{
		movement.enabled = true;
		input.enabled = true;
		combat.enabled = true;
		details.enabled = true;
		animations.enabled = true;
	}
}
