using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public bool jump {
        get {
            return Input.GetKeyDown(KeyCode.Space);
        }
    }

    public float horizontal {
        get {
            return Input.GetAxisRaw("Horizontal");
        }
    }
}
