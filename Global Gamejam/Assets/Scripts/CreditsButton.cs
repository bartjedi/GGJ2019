using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsButton : MonoBehaviour
{
	[SerializeField]
	private TextMesh tm;

	public void SetText(string nameText)
	{
		tm.text= nameText;
	}
}
