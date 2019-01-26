using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class CharacterSelectionController : MonoBehaviour
{
    XboxController xboxController;
    [SerializeField]
    private int playerNumber = -1;
    private List<PlayerController> characters;
    private int activeChar = 0;
    private bool canSwap = true;
    private bool canConfirm = false;
    [SerializeField]
    private float swapTimer = 0.25f;
    [SerializeField]
    private float confirmTimer = 1;
    [SerializeField]
    private float offset = 2;

    private void Start()
    {
        characters = new List<PlayerController>();
        int i = 0;
        foreach (PlayerController character in CharacterSelection.instance.characters)
        {
            characters.Add(Instantiate(character, transform));
            characters[i].gameObject.SetActive(false);
            i++;
        }
    }

    private void Update()
    {
        if (playerNumber != -1)
        {
            if (XCI.GetAxis(XboxAxis.LeftStickX, xboxController) < -0.2f)
            {
                if (canSwap)
                {
                    Left();
                }
            }
            else if (XCI.GetAxis(XboxAxis.LeftStickX, xboxController) > 0.2f)
            {
                if (canSwap)
                {
                    Right();
                }
            }
            if (XCI.GetButtonUp(XboxButton.A, xboxController))
            {
                if (canConfirm)
                {
                    CharacterSelection.instance.Confirm(playerNumber, activeChar, transform.position, xboxController);
                }
            }
            if (XCI.GetButtonUp(XboxButton.B, xboxController))
            {
				canConfirm = false;
				characters[activeChar].gameObject.SetActive(false);
                //activeChar = 0; Commented out so that the previous choice of the player is remembered
                CharacterSelection.instance.Leave(playerNumber);
				playerNumber = 0;
			}
        }
    }

    public void Activate(int playerN)
    {
        transform.position = new Vector3(transform.position.x + (offset * playerN), transform.position.y, transform.position.z);
        this.playerNumber = playerN;
        switch (playerNumber)
        {
            case 0: xboxController = XboxController.First; break;
            case 1: xboxController = XboxController.Second; break;
            case 2: xboxController = XboxController.Third; break;
            case 3: xboxController = XboxController.Fourth; break;
        }
        characters[activeChar].gameObject.SetActive(true);
        StartCoroutine(WaitForConfirm());
    }

    public void Left()
    {
        activeChar--;
        if (activeChar < 0)
        {
            activeChar = characters.Count - 1;
        }
        ActivateChar();
    }

    public void Right()
    {
        activeChar++;
        if (activeChar >= characters.Count)
        {
            activeChar = 0;
        }
        ActivateChar();
    }

    private void ActivateChar()
    {
        canSwap = false;
        StartCoroutine(WaitForSwap());
        for(int i=0;i< characters.Count; i++)
        {
            if (i != activeChar)
                characters[i].gameObject.SetActive(false);
            else
                characters[i].gameObject.SetActive(true);
        }
    }

    IEnumerator WaitForSwap()
    {
        yield return new WaitForSeconds(swapTimer);
        canSwap = true;
    }

    IEnumerator WaitForConfirm()
    {
        yield return new WaitForSeconds(confirmTimer);
        canConfirm = true;
    }
}
