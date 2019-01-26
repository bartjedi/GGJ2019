using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
	public enum States { MENU, PLAYING, PAUSED };
	public enum Languages { English, Spanish, German, Chinese };
	public int gameState;
	public int language;
    public Material[] materials;

    public static GameManagerScript instance = null;             

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            if (instance != this)
            {
                Destroy(gameObject);
            }
        }
    }


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
