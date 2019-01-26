using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class PlayerInput : MonoBehaviour
{
	public XboxController controller;

    public bool jump {
        get {
			//return XCI.GetButtonDown(XboxButton.DOE HIER BUTTON A WASILI);
			return false;
        }
    }

    public float horizontal {
        get {
			return XCI.GetAxis(XboxAxis.LeftStickX, controller);
        }
    }

	public float vertical {
		get {
			return XCI.GetAxis(XboxAxis.LeftStickY, controller);
		}
	}
}
