using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    private PlayerController controller;
    [SerializeField]
    private float shoveForce = 1.0f, recoveryTime = 1.0f, attackReach = 1.5f, attackCooldown = 0.5f;
    private float colliderBorder;

    private float attackedTime = float.NegativeInfinity, attackTime = float.NegativeInfinity;

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

	public void GetAttacked(Vector3 direction, float force) {
        attackedTime = Time.time;
        controller.movement.ApplyForce(direction * force + new Vector3(0.0f, 100f, 0.0f));
    }

    private void Attack() {
        if (nearestPlayer != null && attackTime + attackCooldown < Time.time) {
            nearestPlayer.combat.GetAttacked(transform.right, shoveForce);
            attackTime = Time.time;
        }
    }
}
