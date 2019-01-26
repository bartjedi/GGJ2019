using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
	public enum States { MENU, PLAYING, PAUSED };
	public enum Languages { English, Spanish, German, Chinese };
	public int gameState;
	public int language;

	// Start is called before the first frame update
	void Start()
    {
		gameState = (int)States.MENU;
		language = (int)Languages.English;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
