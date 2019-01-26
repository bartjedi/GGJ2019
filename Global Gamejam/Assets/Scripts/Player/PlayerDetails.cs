using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetails : MonoBehaviour
{
    public int playerHealth;
	public Material character;

    void Start()
    {
        GameManagerScript.instance.AddPlayer(this);   
    }
}
