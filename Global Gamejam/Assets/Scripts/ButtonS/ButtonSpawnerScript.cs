using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSpawnerScript : MonoBehaviour
{
	private GameObject gameManager;
	private GameManagerScript gms;

	[SerializeField]
	private List<GameObject> buttonPossibilities;

	[SerializeField]
	private float newButtonNeededPosition = -5.0f;
	[SerializeField]
	private GameObject highestButton;

	[SerializeField]
	private float jumpHeight = 5.0f;
	[SerializeField]
	private float leftSideScreen = -50.0f;
	[SerializeField]
	private float rightSideScreen = 100.0f;

	[SerializeField]
	private GameObject startButton;
	[SerializeField]
	private GameObject optionsButton;
	[SerializeField]
	private GameObject exitButton;
	[SerializeField]
	private GameObject blankButton;
	[SerializeField]
	private GameObject languageButton;
	[SerializeField]
	private GameObject sceneButton;
	[SerializeField]
	private GameObject saveButton;
	[SerializeField]
	private GameObject loadButton;

	// Start is called before the first frame update
	void Start()
    {
		gameManager = GameObject.Find("GameManager");
		gms = (GameManagerScript)gameManager.GetComponent<GameManagerScript>();

		buttonPossibilities.Add(startButton);
		buttonPossibilities.Add(optionsButton);
		buttonPossibilities.Add(exitButton);
		buttonPossibilities.Add(blankButton);
		buttonPossibilities.Add(languageButton);
		buttonPossibilities.Add(sceneButton);
		buttonPossibilities.Add(saveButton);
		buttonPossibilities.Add(loadButton);
	}

    // Update is called once per frame
    void Update()
    {
		// While the game is playing
		// if(gms.gameState == (int)GameManagerScript.States.PLAYING) {

		// When the highest button is below a certain point 
		if(highestButton.transform.position.y < newButtonNeededPosition)
		{
			createNewButton();
		}
		
		

        
    }

	// Random button generator
	GameObject GetRandomButton()
	{
		return (GameObject)buttonPossibilities[Random.Range(0, buttonPossibilities.Count)];
	}

	Vector3 GetRandomButRealisticPosition()
	{
		var newX = Random.Range(leftSideScreen, rightSideScreen);
		var newY = Random.Range(highestButton.transform.position.y, highestButton.transform.position.y + jumpHeight);
		//Debug.Log("New coordinates " + newX + " , " + newY);

		return new Vector3(newX, newY, 0.0f);
	}

	void createNewButton()
	{
		var newButton = GetRandomButton();
		Debug.Log(newButton);
		var newPosition = GetRandomButRealisticPosition();

		highestButton = Instantiate(newButton, newPosition, Quaternion.identity);
	}

}

