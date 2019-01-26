using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButtonScript : ButtonScript
{
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
		// Start game
		if(GameManagerScript.instance.gameState == GameManagerScript.States.PAUSED)
		{
			ResumeGame();
		}
		else if(GameManagerScript.instance.gameState == GameManagerScript.States.MENU)
		{
			StartGame();
		}
	}

	void ResumeGame()
	{
        GameManagerScript.instance.gameState = GameManagerScript.States.PLAYING;
	}

	void StartGame()
	{
        GameManagerScript.instance.gameState = GameManagerScript.States.PLAYING;
	}
}
