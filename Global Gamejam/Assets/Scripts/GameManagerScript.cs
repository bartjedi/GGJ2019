using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    private int maxLanguages, maxBackgrounds;
    [SerializeField]
    private SpriteRenderer background;
    [SerializeField]
    private Sprite[] backgrounds;
    private AudioSource audioSource;
    private List<PlayerDetails> players;
    private List<Transform> playerLocations;

    private int changeControlTimer;

    public enum States { Menu, Playing, Paused, Finished };
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
    }

    // Start is called before the first frame update
    void Start()
    {
        players = new List<PlayerDetails>();
        playerLocations = new List<Transform>();
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
        int randomBackground = Random.Range(0, maxBackgrounds);
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

    public void AddPlayer(PlayerDetails player)
    {
        players.Add(player.GetComponent<PlayerDetails>());
    }

    public void SavePositions()
    {
        foreach(PlayerDetails player in players)
        {
            playerLocations.Add(player.transform);
        }
    }

    public void LoadPositions()
    {
        int i = 0;
        foreach(PlayerDetails player in players)
        {
            player.transform.position = playerLocations[i].position;
            player.transform.rotation = playerLocations[i].rotation;
            i++;
        }
    }
}
