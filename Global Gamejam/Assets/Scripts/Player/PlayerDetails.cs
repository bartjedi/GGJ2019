using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetails : MonoBehaviour
{
    public int playerHealth;
    void Start()
    {
        GameManagerScript.instance.AddPlayer(this);   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
