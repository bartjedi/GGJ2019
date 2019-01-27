using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlankButtonScript : ButtonScript
{
	private int jumpedOn = 0;
	[SerializeField]
	private int amountOfJumpsAllowed = 3;

	override public void Jumped()
	{
		jumpedOn++;
		if(jumpedOn >= amountOfJumpsAllowed)
		{
			Destroy(this.gameObject);
		}
	}

    public override void Trigger(GameObject player)
    {
        Destroy(this.gameObject);
    }
}
