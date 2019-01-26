using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class GameManagerScript : MonoBehaviour
{
    private int maxLanguages, maxBackgrounds;
    [SerializeField]
    private SpriteRenderer background;
    [SerializeField]
    private Sprite[] backgrounds;
    private AudioSource audioSource;
    public List<PlayerDetails> players;
    private List<Vector3> playerLocations;

    private int changeControlTimer;

    public enum States { Menu, CharacterSelection, Playing, Paused, Finished };
	public enum Languages { English, Spanish, German, Chinese };
	public States gameState;
	public Languages language;
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
        players = new List<PlayerDetails>();
        playerLocations = new List<Vector3>();
    }

    // Start is called before the first frame update
    void Start()
    {
        playerLocations = new List<Vector3>();
		gameState = States.Menu;
		//gameState = States.Playing;
		language = Languages.English;
        maxLanguages = System.Enum.GetValues(typeof(Languages)).Length;
        maxBackgrounds = backgrounds.Length;
    }

    public void ChangeLanguage()
    {
        int randomLanguage = Random.Range(0, maxLanguages);
        if(randomLanguage == (int)language)
        {
            randomLanguage++;
            if (randomLanguage > maxLanguages)
            {
                randomLanguage = 0;
            }
        }

        switch (randomLanguage)
        {
            case 0: language = Languages.English; break;
            case 1: language = Languages.Spanish; break;
            case 2: language = Languages.German; break;
            case 3: language = Languages.Chinese; break;
        }
    }

    public void ChangeBackground()
    {
        int randomBackground = Random.Range(0, maxBackgrounds-1);
        if (randomBackground == (int)language)
        {
            randomBackground++;
            if (randomBackground > maxLanguages)
            {
                randomBackground = 0;
            }
        }
        background.sprite = backgrounds[randomBackground];
    }

    public void ChangeControls()
    {
        foreach(PlayerDetails player in players)
        {
            player.GetComponent<PlayerInput>().ChangeControls(changeControlTimer);
        }
    }

    public void AddPlayer(PlayerController player)
    {
        players.Add(player.GetComponent<PlayerDetails>());
    }

    public void SavePositions()
    {
        playerLocations.Clear();
        Debug.Log(players.Count);
        foreach(PlayerDetails player in players)
        {
            playerLocations.Add(player.transform.position);
        }
    }

    public void LoadPositions()
    {
        if (playerLocations.Count > 0)
        {
            int i = 0;
            foreach (PlayerDetails player in players)
            {
                player.gameObject.transform.position = playerLocations[i];
                i++;
            }
        }
    }

    public void Spawn(PlayerController playerCharacter, int playerNumber, Vector3 position, XboxController xboxController)
    {
		PlayerController player = Instantiate(playerCharacter, position, new Quaternion(0, 0, 0, 0));
		player.Entry();
        AddPlayer(player);
        player.GetComponent<PlayerInput>().xboxController = xboxController;
        //TODO: add jumping out animation
    }
}
