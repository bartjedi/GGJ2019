using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsButtonScript : ButtonScript
{
    public override void Trigger(GameObject player)
    {
        base.Break();
        GameManagerScript.instance.ChangeControls();
    }
}
