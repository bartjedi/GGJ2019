using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credits : MonoBehaviour
{
	[SerializeField]
	private string[] names;
	[SerializeField]
	CreditsButton creditsButton;

	void Update()
	{
		Trigger();
	}

	public void Trigger()
	{
		for(int i=0; i< names.Length; i++)
		{
			CreditsButton cb=Instantiate(creditsButton, new Vector3(Camera.main.ViewportToWorldPoint(new Vector2(Random.value,0)).x,Camera.main.ViewportToWorldPoint(new Vector2(0,1)).y,0), creditsButton.transform.rotation);
			cb.SetText(names[i]);
		}
	}
}
