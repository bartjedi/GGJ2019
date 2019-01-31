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
        // nani de fuck neuk
        return;
		jumpedOn++;
		if(jumpedOn >= amountOfJumpsAllowed)
		{
			Destroy(this.gameObject);
		}
	}

    public override void Trigger(GameObject player)
    {
        textureImage.enabled = true;
        jumpedOn++;

        ps.Play();

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
