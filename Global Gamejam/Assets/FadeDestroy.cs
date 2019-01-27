using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeDestroy : MonoBehaviour
{
	Image img;

	IEnumerator Start()
	{
		Color c = img.color;
		while (c.a > 0.0f)
		{
			c.a -= Time.deltaTime;
			img.color = c;
			yield return new WaitForEndOfFrame();
		}
		Destroy(this.gameObject);
	}
}
