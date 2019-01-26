using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
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
            return Input.GetKeyDown(KeyCode.Space) && allowJump && allowInput;
        }
    }

    public float horizontal
    {
        get
        {
            return Input.GetAxisRaw("Horizontal");
        }
    }

    public bool attack
    {
        get
        {
            return Input.GetKeyDown(KeyCode.Q) && allowAttack && allowInput;
        }
    }
}
