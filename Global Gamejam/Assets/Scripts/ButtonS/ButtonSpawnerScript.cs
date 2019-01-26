using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSpawnerScript : MonoBehaviour
{
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
    private GameObject[] buttons;

    // Update is called once per frame
    private void Update()
    {
        // When the highest button is below a certain point 
        if (GameManagerScript.instance.gameState == GameManagerScript.States.Playing)
        {
            if (highestButton.transform.position.y < newButtonNeededPosition)
            {
                CreateNewButton();
            }
        }
    }

	// Random button generator
	private GameObject GetRandomButton()
	{
		return buttons[Random.Range(0, buttons.Length)];
	}

	private Vector3 GetRandomButRealisticPosition()
	{
		var newX = Random.Range(leftSideScreen, rightSideScreen);
		var newY = Random.Range(highestButton.transform.position.y, highestButton.transform.position.y + jumpHeight);
		return new Vector3(newX, newY, 0.0f);
	}

    private void CreateNewButton()
    {
        GameObject newButton = GetRandomButton();
        Vector3 newPosition = GetRandomButRealisticPosition();

        highestButton = Instantiate(newButton, newPosition, Quaternion.identity);
    }
}