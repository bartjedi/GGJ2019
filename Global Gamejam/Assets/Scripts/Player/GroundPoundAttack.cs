using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundPoundAttack : MonoBehaviour
{
    [SerializeField]
    private PlayerCombat combat;

    private void OnTriggerEnter(Collider other)
    {
        PlayerController pc;
        if ((pc = other.GetComponent<PlayerController>()) != null)
        {
            combat.PoundEnemy(pc);
            return;
        }

    }
}
