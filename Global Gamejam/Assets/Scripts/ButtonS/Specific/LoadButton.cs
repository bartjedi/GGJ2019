using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadButton : ButtonScript
{
    override public void Trigger(GameObject player)
    {
        base.Break();
        Debug.Log("test");
        GameManagerScript.instance.LoadPositions();
    }
}

