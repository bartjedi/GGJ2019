using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CreditsButton : MonoBehaviour
{
	[SerializeField]
	private TextMeshProUGUI tm;

	public void SetText(string nameText)
	{
		tm.text= nameText;
	}
}
