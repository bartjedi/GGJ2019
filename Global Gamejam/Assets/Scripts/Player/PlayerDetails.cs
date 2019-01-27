using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetails : MonoBehaviour
{
	public int playerNr;
	public int startHealth = 3;
    public int playerHealth = 3;
    public enum modelType { Red, Blue, Yellow, Green, Purple};
    public modelType myModel;
    public enum finishedAs { Fourth, Third, Second, First}
    public finishedAs finished;

    private void Start()
    {
        GameManagerScript.instance.AddPlayer(this.GetComponent<PlayerController>());
		UpdateStats();
    }

	public void Died()
	{
		if(playerHealth > 0)
		{
			playerHealth--;
			UpdateStats();
		}
		else
		{
			Destroy(gameObject);
            DeathManager.instance.Died(this);
		}
		
	}

	private void UpdateStats()
	{
		GameManagerScript.instance.huds[playerNr].GetComponent<PlayerStatsScript>().UpdateStats(playerHealth, startHealth);
	}
}
