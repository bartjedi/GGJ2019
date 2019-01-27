using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathManager : MonoBehaviour
{
    public int players;
    public List<PlayerDetails> playerList = new List<PlayerDetails>();
    public PlayerDetails.modelType first, second, third, fourth;
    public int died = 0;
    AsyncOperation async;
    
    public static DeathManager instance = null;
    // Start is called before the first frame update
    void Start()
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
        DontDestroyOnLoad(this);
        async = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        async.allowSceneActivation = false;
    }

    public void Died(PlayerDetails player)
    {
        players = GameManagerScript.instance.activePlayers;
        died++;
        foreach (PlayerDetails play in playerList)
        {
            if(play.playerNr == player.playerNr)
            {
                SetPosition(play);
            }
        }
    }

    private void SetPosition(PlayerDetails player)
    {
        if(players == 2)
        {
            player.finished = PlayerDetails.finishedAs.Second;
            SetModels();
        }
        if (players == 3)
        {
            if (died == 1)
            {
                player.finished = PlayerDetails.finishedAs.Third;
            }
            if (died ==2 )
            {
                player.finished = PlayerDetails.finishedAs.Second;
                Debug.Log("test");
                SetModels();
            }
        }
        if (players == 4)
        {
            if (died == 1)
            {

                player.finished = PlayerDetails.finishedAs.Fourth;
            }
            if (died == 2)
            {
                player.finished = PlayerDetails.finishedAs.Third;
            }
            if( died == 3)
            {
                player.finished = PlayerDetails.finishedAs.Second;
                SetModels();
            }
        }
    }

    private void SetModels()
    {
        foreach(PlayerDetails play in playerList)
        {
            switch (play.finished)
            {
                case PlayerDetails.finishedAs.First: first = play.myModel; break;
                case PlayerDetails.finishedAs.Second: second = play.myModel; break;
                case PlayerDetails.finishedAs.Third: third = play.myModel; break;
                case PlayerDetails.finishedAs.Fourth: fourth = play.myModel; break;
            }
        }
        async.allowSceneActivation = true;
    }
}
