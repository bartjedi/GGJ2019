using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSpawnerScript : MonoBehaviour
{
	[SerializeField]
	private float newButtonNeededPosition = -4;
	[SerializeField]
	private GameObject lowest;
    [SerializeField]
    private float bottomOfScreen;

	[SerializeField]
	private float jumpHeight = 5.0f;
	[SerializeField]
	private float leftSideScreen = -50.0f;
	[SerializeField]
	private float rightSideScreen = 100.0f;
    [SerializeField]
    private float spawnRate = 3.0f;
    [SerializeField]
    private GameObject[] buttons;

    float lastSpawn = float.MinValue;

    private void Start()
    {
        bottomOfScreen = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 15.75f)).y;
    }

    // Update is called once per frame
    private void Update()
    {
        // When the highest button is below a certain point 
        if (GameManagerScript.instance.gameState == GameManagerScript.States.Playing)
        {
            //if (lowest.transform.position.y > newButtonNeededPosition)
            //{
            //    CreateNewButton();
            //}
            if (lastSpawn + spawnRate < Time.time) {
                CreateNewButton();
                lastSpawn = Time.time;
            }
        }
    }

	// Random button generator
	private GameObject GetRandomButton()
	{
		return buttons[Random.Range(0, buttons.Length)];
	}

    // nani the fuck neuk pt2
	private Vector3 GetRandomButRealisticPosition()
	{
		var newX = Random.Range(leftSideScreen, rightSideScreen);
		//var newY = Random.Range(lowest.transform.position.y, lowest.transform.position.y + jumpHeight);
		return new Vector3(newX, bottomOfScreen, 0.0f);
	}

    private void CreateNewButton()
    {
        GameObject newButton = GetRandomButton();
        Vector3 newPosition = GetRandomButRealisticPosition();
        Instantiate(newButton, newPosition, Quaternion.identity);
    }
}