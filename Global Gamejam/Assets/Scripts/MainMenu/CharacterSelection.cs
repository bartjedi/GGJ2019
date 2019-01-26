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
    public GameObject[] characters;
    [SerializeField]
    private PlayerDetails[] selectedCharacters;
    private int[] playersSelected;
    private bool[] playerActive;
    private CharacterSelectionController[] characterSelectionControllers;
    [SerializeField]
    private CharacterSelectionController characterSelectionController;
    [SerializeField]
    private TextMesh toJoin;
    [SerializeField]
    private TextMesh selectChar;


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
            characterSelectionControllers[0].Activate(0);
        }
        if (XCI.GetButtonUp(XboxButton.A, XboxController.Second) && !playerActive[1])
        {
            playerActive[1] = true;
            characterSelectionControllers[1].Activate(1);
        }
        if (XCI.GetButtonUp(XboxButton.A, XboxController.Third) && !playerActive[2])
        {
            playerActive[2] = true;
            characterSelectionControllers[2].Activate(2);
        }
        if (XCI.GetButtonUp(XboxButton.A, XboxController.Fourth) && !playerActive[3])
        {
            playerActive[3] = true;
            characterSelectionControllers[3].Activate(3);
        }
        if (playerActive[0] && playerActive[1] && playerActive[2] && playerActive[3])
        {
            toJoin.gameObject.SetActive(true);
        }
        if(playerActive[0] || playerActive[1] || playerActive[2] || playerActive[3])
        {
            selectChar.gameObject.SetActive(true);
        }
        else
        {
            selectChar.gameObject.SetActive(false);
        }
    }

    public void Confirm(int playerNumber, int charNumber, Vector3 position, XboxController xboxController)
    {
        characterSelectionControllers[playerNumber].gameObject.SetActive(false);
        GameManagerScript.instance.Spawn(selectedCharacters[charNumber], playerNumber, position, xboxController);
    }

    public void Leave(int playerNumber)
    {
        playerActive[playerNumber] = false;
    }
}
