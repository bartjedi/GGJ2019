using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitButtonScript : ButtonScript
{
    public override void Trigger()
    {
        base.Break();
        //PlayerDetails.Kill();
    }
}
