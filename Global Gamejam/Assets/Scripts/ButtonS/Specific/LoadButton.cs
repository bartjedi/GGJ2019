using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadButton : ButtonScript
{
    override public void Trigger()
    {
        base.Break();
        Debug.Log("test");
        GameManagerScript.instance.LoadPositions();
    }
}

