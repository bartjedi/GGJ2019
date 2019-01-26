using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class PlayerInput : MonoBehaviour
{

    public XboxController xboxController;
    public bool allowInput { get; set; }
    public bool allowMovement { get; set; }
    public bool allowJump { get; set; }
    public bool allowAttack { get; set; }

    private void Awake()
    {
        allowInput = true;
        allowJump = true;
        allowAttack = true;
        allowMovement = true;
    }

    public bool jump
    {
        get
        {
            return XCI.GetButtonDown(XboxButton.A) && allowJump && allowInput;
        }
    }

    public bool attack
    {
        get
        {
            return XCI.GetButtonDown(XboxButton.B) && allowAttack && allowInput;
        }
    }

    public float horizontal {
        get {
            return XCI.GetAxis(XboxAxis.LeftStickX, xboxController);
        }
    }

	public float vertical {
		get {
            return XCI.GetAxis(XboxAxis.LeftStickY, xboxController);
		}
	}
}
