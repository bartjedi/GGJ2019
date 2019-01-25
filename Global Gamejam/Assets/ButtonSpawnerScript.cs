using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSpawnerScript : MonoBehaviour
{
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

    // Start is called before the first frame update
    void Start()
    {
		buttonPossibilities.Add(startButton);
		buttonPossibilities.Add(optionsButton);
		
    }

    // Update is called once per frame
    void Update()
    {
		// While the game is playing
		// if(gameState == PLAYING) {

		// When the highest button is below a certain point 
		if(highestButton.transform.position.y < newButtonNeededPosition)
		{
			createNewButton();
		}
		
		

        
    }

	// Random button generator
	GameObject GetRandomButton()
	{
		return (GameObject)buttonPossibilities[Random.Range(0, buttonPossibilities.Count - 1)];
	}

	Vector3 GetRandomButRealisticPosition()
	{
		var newX = Random.Range(leftSideScreen, rightSideScreen);
		var newY = Random.Range(highestButton.transform.position.y, highestButton.transform.position.y + jumpHeight);
		//Debug.Log("New coordinates " + newX + " , " + newY);

		return new Vector3(newX, newY, highestButton.transform.position.z);
	}

	void createNewButton()
	{
		var newButton = GetRandomButton();
		var newPosition = GetRandomButRealisticPosition();

		highestButton = Instantiate(newButton, newPosition, Quaternion.identity);
	}

}
