using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundPoundAttack : MonoBehaviour
{
    [SerializeField]
    private PlayerCombat combat;

	private void Awake()
	{
        Physics.IgnoreCollision(GetComponent<Collider>(), combat.GetComponent<Collider>()); 
	}

	private void OnTriggerEnter(Collider other)
    {
        PlayerController pc;
        if ((pc = other.GetComponent<PlayerController>()) != null)
        {
            combat.PoundEnemy(pc);
        }

        ButtonScript bs;

        if ((bs = other.GetComponent<ButtonScript>()) != null)
        {
            combat.PoundButton(bs);
        }
    }

	private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.transform.name);
        PlayerController pc;
        if ((pc = collision.transform.GetComponent<PlayerController>()) != null)
        {
            combat.PoundEnemy(pc);
        }

        ButtonScript bs;

        if ((bs = collision.transform.GetComponent<ButtonScript>()) != null)
        {
            combat.PoundButton(bs);
        }
	}
}
