using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveButton : ButtonScript
{
    override public void Trigger()
    {
        base.Break();
        GameManagerScript.instance.SavePositions();
    }
}
