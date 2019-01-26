using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadButton : ButtonScript
{
    override public void Trigger()
    {
        base.Break();
        GameManagerScript.instance.LoadPositions();
    }
}

