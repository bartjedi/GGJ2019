using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsButtonScript : ButtonScript
{
    [SerializeField]
    private int reverseControlsTimer;

    public override void Trigger()
    {
        //PlayerInput.ReverseControls(reverseControlsTimer);
    }
}
