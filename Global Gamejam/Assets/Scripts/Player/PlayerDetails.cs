using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetails : MonoBehaviour
{
	public int playerNr;
	public int startHealth;
    public int playerHealth;

    private void Start()
    {
        GameManagerScript.instance.AddPlayer(this.GetComponent<PlayerController>());
		UpdateStats();
    }

	public void Died()
	{
		playerHealth--;
		UpdateStats();
	}

	private void UpdateStats()
	{
		GameManagerScript.instance.huds[playerNr].GetComponent<PlayerStatsScript>().UpdateStats(playerHealth, startHealth);
	}
}
