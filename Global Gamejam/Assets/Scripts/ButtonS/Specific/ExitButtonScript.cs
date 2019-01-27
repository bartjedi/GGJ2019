using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitButtonScript : ButtonScript
{
    public override void Trigger(GameObject player)
    {
        base.Break();
		player.GetComponent<PlayerMovement>().PlayerDies();
    }
}
