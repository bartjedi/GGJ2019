using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class CharacterSelection : MonoBehaviour
{
    [SerializeField]
    private XboxController xboxController;
    [SerializeField]
    private int maxPlayers;
    public PlayerController[] characters;
	public string[] characterNames;
    [SerializeField]
    private PlayerDetails[] selectedCharacters;
    private int[] playersSelected;
    private bool[] playerActive;
    private CharacterSelectionController[] characterSelectionControllers;
    [SerializeField]
    private CharacterSelectionController characterSelectionController;

	private int playerCounter = 0;

	[SerializeField]
	private GameObject[] huds;
	public GameObject[] characterSelectViews;

    public static CharacterSelection instance = null;

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
		StartButtonScript.onStart.Add(KillMe);
    }

    // Start is called before the first frame update
    private void Start()
    {
        playerActive = new bool[maxPlayers];
        characterSelectionControllers = new CharacterSelectionController[maxPlayers];
        for (int i = 0; i < maxPlayers; i++)
        {
            playerActive[i] = false;
            characterSelectionControllers[i] = Instantiate(characterSelectionController, transform);
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if (XCI.GetButtonUp(XboxButton.A, XboxController.First) && !playerActive[0])
        {
            playerActive[0] = true;
			characterSelectViews[0].GetComponent<CharacterSelectionViewScript>().Join();
			characterSelectionControllers[0].Activate(0);
        }
        if (XCI.GetButtonUp(XboxButton.A, XboxController.Second) && !playerActive[1])
        {
            playerActive[1] = true;
			characterSelectViews[1].GetComponent<CharacterSelectionViewScript>().Join();
			characterSelectionControllers[1].Activate(1);
        }
        if (XCI.GetButtonUp(XboxButton.A, XboxController.Third) && !playerActive[2])
        {
            playerActive[2] = true;
			characterSelectViews[2].GetComponent<CharacterSelectionViewScript>().Join();
			characterSelectionControllers[2].Activate(2);
        }
        if (XCI.GetButtonUp(XboxButton.A, XboxController.Fourth) && !playerActive[3])
        {
            playerActive[3] = true;
			characterSelectViews[3].GetComponent<CharacterSelectionViewScript>().Join();
			characterSelectionControllers[3].Activate(3);
        }
    }

    public void Confirm(int playerNumber, int charNumber, Vector3 position, XboxController xboxController)
    {
	
		huds[playerCounter].GetComponent<PlayerStatsScript>().Setup(charNumber);
		playerCounter++;
		characterSelectionControllers[playerNumber].gameObject.SetActive(false);
        GameManagerScript.instance.Spawn(characters[charNumber], playerNumber, position, xboxController);
    }

    public void Leave(int playerNumber)
    {
        playerActive[playerNumber] = false;
		characterSelectViews[playerNumber].GetComponent<CharacterSelectionViewScript>().Leave();
    }

	private void KillMe()
	{
		Destroy(gameObject);
	}
}
