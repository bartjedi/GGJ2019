using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanguageButtonScript : ButtonScript
{
    /// <summary>
    /// Call this function to trigger the specific event for this button
    /// </summary>
	override public void Trigger()
	{
        GameManagerScript.instance.ChangeLanguage();
	}
}
