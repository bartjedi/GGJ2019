using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButtonScript : ButtonScript
{
	private int probability = 2;
	//private List<string> buttonText = ["Start", "Comienzo", "Start", "开始"];

	// Start is called before the first frame update
	void Start()
    {
		//this.transform.Find("ButtonText").gameObject.GetComponent<TextMesh>().text = buttonText[gms.language];
	}

	// Update is called once per frame
	void Update()
    {
		base.Update();
    }

	void Function()
	{
		// Start game
		if(gms.gameState == (int)GameManagerScript.States.PAUSED)
		{
			ResumeGame();
		}
		else if(gms.gameState == (int)GameManagerScript.States.MENU)
		{
			StartGame();
		}
	}

	void ResumeGame()
	{
		gms.gameState = (int)GameManagerScript.States.PLAYING;
	}

	void StartGame()
	{
		gms.gameState = (int)GameManagerScript.States.PLAYING;
	}
}
