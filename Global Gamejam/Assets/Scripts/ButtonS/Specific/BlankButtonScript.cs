using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlankButtonScript : ButtonScript
{
	private int jumpedOn = 0;
	[SerializeField]
	private int amountOfJumpsAllowed = 3;

    // Start is called before the first frame update
    void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
		base.Update();
	}

	void Function()
	{
		jumpedOn++;
		if(jumpedOn >= amountOfJumpsAllowed)
		{
			Destroy(this.gameObject);
		}
	}
}
