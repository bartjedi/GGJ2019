using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlankButtonScript : ButtonScript
{
	private int jumpedOn = 0;
	[SerializeField]
	private int amountOfJumpsAllowed = 3;
    [SerializeField]
    private Image textureImage;
    [SerializeField]
    private Sprite[] breakTextures;
    private int curTexture = -1;

	override public void Jumped()
	{
        return;
		jumpedOn++;
		if(jumpedOn >= amountOfJumpsAllowed)
		{
			Destroy(this.gameObject);
		}
	}

    public override void Trigger()
    {
        textureImage.enabled = true;
        jumpedOn++;
        if (curTexture < breakTextures.Length - 1) {
            curTexture++;
        }
        Debug.Log(curTexture);
        textureImage.sprite = breakTextures[curTexture];
        if (jumpedOn >= amountOfJumpsAllowed)
        {
            base.Break();
        }
    }
}
