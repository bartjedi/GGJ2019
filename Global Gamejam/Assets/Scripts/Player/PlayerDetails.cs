using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetails : MonoBehaviour
{
    public int playerHealth;

    private void Start()
    {
        GameManagerScript.instance.AddPlayer(this.GetComponent<PlayerController>());
    }
}
