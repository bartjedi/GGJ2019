using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class PlayerInput : MonoBehaviour
{
    public bool isMac = false;
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
            if (isMac)
                return XCI.GetButtonDown(XboxButton.A) && allowJump && allowInput;
            return Input.GetKeyDown(KeyCode.Space) && allowJump && allowInput;
        }
    }

    public bool attack
    {
        get
        {
            if (isMac)
                return XCI.GetButtonDown(XboxButton.B) && allowAttack && allowInput;
            return Input.GetKeyDown(KeyCode.Q) && allowAttack && allowInput;
        }
    }

    public float horizontal
    {
        get
        {
            if (isMac)
                return XCI.GetAxis(XboxAxis.LeftStickX, xboxController);
            return Input.GetAxisRaw("Horizontal");
        }
    }

    public float vertical
    {
        get
        {
            if (isMac)
                return XCI.GetAxis(XboxAxis.LeftStickY, xboxController);
            return Input.GetAxisRaw("Vertical");
        }
    }
}
