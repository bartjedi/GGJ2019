using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButtonScript : ButtonScript
{
	public static List<Action> onStart = new List<Action>();

	override public void Trigger()
    {
        base.Break();
		// Start game
		if(GameManagerScript.instance.gameState == GameManagerScript.States.Paused)
		{
			ResumeGame();
		}
		else if(GameManagerScript.instance.gameState == GameManagerScript.States.Menu)
		{
			StartGame();
			foreach (Action a in onStart)
			{
				a();
			}
		}
	}

	public void ResumeGame()
	{
        GameManagerScript.instance.gameState = GameManagerScript.States.Playing;
	}

	public void StartGame()
	{
        GameManagerScript.instance.gameState = GameManagerScript.States.Playing;
		this.GetComponent<Rigidbody>().useGravity = true;
	}

	private void OnDestroy()
	{
		onStart.Clear();
	}
}
