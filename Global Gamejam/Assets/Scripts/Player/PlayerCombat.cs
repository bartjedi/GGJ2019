using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    private PlayerController controller;
    [SerializeField]
    private float shoveForce = 1.0f, recoveryTime = 1.0f, attackReach = 1.5f;
    private float colliderBorder;

    private float attackedTime;

    private PlayerController nearestPlayer {
        get {
            PlayerController c = null;

            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.right, out hit, colliderBorder + attackReach)) {
                c = hit.transform.GetComponent<PlayerController>();
            }
            return c;
        }
    }

	private void Awake()
	{
        controller = GetComponent<PlayerController>();
        colliderBorder = GetComponent<Collider>().bounds.extents.x;
	}

	private void Update()
	{
        if (controller.input.attack) {
            Attack();
        }
        controller.input.allowMovement = attackedTime + recoveryTime < Time.time;
	}

	public void GetAttacked() {
        attackedTime = Time.time;
        controller.movement.ApplyForce(transform.right * shoveForce + new Vector3(0.0f, 100f, 0.0f));
    }

    private void Attack() {
        if (nearestPlayer != null) {
            nearestPlayer.combat.GetAttacked();
        }
    }
}
