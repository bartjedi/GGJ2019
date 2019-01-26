using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class PlayerInput : MonoBehaviour
{
    public bool isNotMac = false;
    public XboxController xboxController;
    public bool allowInput { get; set; }
    public bool allowMovement { get; set; }
    public bool allowJump { get; set; }
    public bool allowAttack { get; set; }
    private bool changedControls = false;

    private void Awake()
    {
        allowInput = true;
        allowJump = true;
        allowAttack = true;
        allowMovement = true;
    }

    public void ChangeControls(int changedControlTimer)
    {
        changedControls = true;
        StartCoroutine(ChangedControls(changedControlTimer));
    }

    IEnumerator ChangedControls(int changedControlsTimer)
    {
        yield return new WaitForSeconds(10);
        changedControls = false;
    }

    public bool jump
    {
        get
        {
            if (isNotMac)
            {
                if (!changedControls)
                {
                    return XCI.GetButtonDown(XboxButton.A, xboxController) && allowJump && allowInput;
                }
                else
                {
                    Debug.Log("false");
                    return XCI.GetButtonDown(XboxButton.B, xboxController) && allowJump && allowInput;
                }
            }
            return Input.GetKeyDown(KeyCode.Space) && allowJump && allowInput;
        }
    }

    public bool shove
    {
        get
        {
            if (isNotMac)
            {
                if (!changedControls)
                {
                    return XCI.GetButtonDown(XboxButton.B, xboxController) && allowAttack && allowInput;
                }
                else
                {
                    return XCI.GetButtonDown(XboxButton.A, xboxController) && allowAttack && allowInput;
                }
            }
            return Input.GetKeyDown(KeyCode.Q) && allowAttack && allowInput;
        }
    }

    public bool groundPound
    {
        get
        {
            if (isNotMac)
                return XCI.GetButtonDown(XboxButton.X, xboxController) && allowAttack && allowInput;
            return Input.GetAxisRaw("Vertical") < 0.0f && allowAttack && allowInput;
        }
    }

    public float horizontal
    {
        get
        {
            if (isNotMac)
                return XCI.GetAxis(XboxAxis.LeftStickX, xboxController);
            return Input.GetAxisRaw("Horizontal");
        }
    }

    public float vertical
    {
        get
        {
            if (isNotMac)
                return XCI.GetAxis(XboxAxis.LeftStickY, xboxController);
            return Input.GetAxisRaw("Vertical");
        }
    }
}
