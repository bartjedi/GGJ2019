using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButtonScript : ButtonScript
{
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
		}
	}

	public void ResumeGame()
	{
        GameManagerScript.instance.gameState = GameManagerScript.States.Playing;
	}

	public void StartGame()
	{
        GameManagerScript.instance.gameState = GameManagerScript.States.Playing;
	}
}
