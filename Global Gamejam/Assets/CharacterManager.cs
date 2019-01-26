using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class CharacterManager : MonoBehaviour
{
	public XboxController xboxController;

	private GameManagerScript gms;

	[SerializeField]
	private GameObject playerCharacter1;
	[SerializeField]
	private GameObject playerCharacter2;
	[SerializeField]
	private GameObject playerCharacter3;
	[SerializeField]
	private GameObject playerCharacter4;

	private PlayerDetails ps1;
	private PlayerDetails ps2;
	private PlayerDetails ps3;
	private PlayerDetails ps4;

	[SerializeField]
	private GameObject joinText;

	private int playersActive = 0;
	[SerializeField]
	private float characterPlacementY = 4.0f;
	private Vector3 characterPlacement1;
	private Vector3 characterPlacement2;
	private Vector3 characterPlacement3;
	private Vector3 characterPlacement4;

	private Vector3 startPoint;
	private Vector3 endPoint;
	private float speed = 1.0f;
	private float startTime;
	private float journeyLength;

	private bool characterHasBeenAdded = false;

	private Material[] materials;
	private List<Material> materialList;
	private List<Material> chosenList;

	private int p1C = 0, p2C = 1, p3C = 2, p4C = 3;

	// Start is called before the first frame update
	void Start()
    {
		gms = (GameManagerScript)GameObject.Find("GameManager").GetComponent<GameManagerScript>();
		
		materials = GameManagerScript.instance.materials;
		resetMaterialList();

		characterPlacement1 = new Vector3(2.12f, characterPlacementY, 0.0f);
		characterPlacement2 = new Vector3(1.35f, characterPlacementY, 0.0f);
		characterPlacement3 = new Vector3(0.13f, characterPlacementY, 0.0f);
		characterPlacement4 = new Vector3(-1.09f, characterPlacementY, 0.0f);

		this.transform.position = characterPlacement1;

		playerCharacter1.SetActive(false);
		playerCharacter2.SetActive(false);
		playerCharacter3.SetActive(false);
		playerCharacter4.SetActive(false);

		joinText.SetActive(true);
	}

    // Update is called once per frame
    void Update()
    {
       // if(gms.gameState == GameManagerScript.States.CharacterSelection)
		//{
			addRemovePlayer();
			characterSelection();

		if(playersActive > 1)
		{
			updatePosition();
		}
			
	//	}
    }

	void addRemovePlayer()
	{
		if(XCI.GetButtonDown(XboxButton.A, XboxController.First))
		{
			addRemoveCharacter(playerCharacter1, !playerCharacter1.activeSelf);
		}
		else if(XCI.GetButtonDown(XboxButton.A, XboxController.Second))
		{
			addRemoveCharacter(playerCharacter2, !playerCharacter2.activeSelf);
		}
		else if (XCI.GetButtonDown(XboxButton.A, XboxController.Third))
		{
			addRemoveCharacter(playerCharacter3, !playerCharacter3.activeSelf);
		}
		else if (XCI.GetButtonDown(XboxButton.A, XboxController.Fourth))
		{
			addRemoveCharacter(playerCharacter4, !playerCharacter4.activeSelf);
		}
	}

	void addRemoveCharacter(GameObject playerCharacter, bool add)
	{
		if(playersActive == 0) { joinText.SetActive(true); }
		else { joinText.SetActive(false); }
		playerCharacter.SetActive(add);
		if(add) { playersActive++; }
		else { playersActive--; }
		startTime = Time.time;
		startPoint = this.transform.position;
		switch (playersActive)
		{
			case 2:
				endPoint = characterPlacement2;
				break;
			case 3:
				endPoint = characterPlacement3;
				break;
			case 4:
				endPoint = characterPlacement4;
				break;
			default:
				break;
		}
		journeyLength = Vector3.Distance(startPoint, endPoint);
	}

	private int indexToLeft(int i)
	{
		if(i <= 0) { return materialList.Count - 1; }
		else { i--; return i; }
	}

	private int indexToRight(int i)
	{
		if(i >= materialList.Count - 1) { return 0; }
		else {	i++; return i; }
	}

	void characterSelection()
	{
		if (playerCharacter1.activeSelf == true)
		{
			if (XCI.GetButtonDown(XboxButton.DPadLeft, XboxController.First))
			{
				p1C = indexToLeft(p1C);
				changeCharacter(playerCharacter1, materialList[p1C]);
			}
			else if (XCI.GetButtonDown(XboxButton.DPadRight, XboxController.First))
			{
				p1C = indexToRight(p1C);
				changeCharacter(playerCharacter1, materialList[p1C]);
			}
		}
		if (playerCharacter2.activeSelf == true)
		{
			if (XCI.GetButtonDown(XboxButton.DPadLeft, XboxController.Second))
			{
				p2C = indexToLeft(p2C);
				changeCharacter(playerCharacter2, materialList[p2C]);
			}
			else if (XCI.GetButtonDown(XboxButton.DPadRight, XboxController.Second))
			{
				p2C = indexToRight(p2C);
				changeCharacter(playerCharacter2, materialList[p2C]);
			}
		}
		if (playerCharacter3.activeSelf == true)
		{
			if (XCI.GetButtonDown(XboxButton.DPadLeft, XboxController.Third))
			{
				p3C = indexToLeft(p3C);
				changeCharacter(playerCharacter3, materialList[p3C]);
			}
			else if (XCI.GetButtonDown(XboxButton.DPadRight, XboxController.Third))
			{
				p3C = indexToRight(p3C);
				changeCharacter(playerCharacter3, materialList[p3C]);
			}
		}
		if (playerCharacter4.activeSelf == true)
		{
			if (XCI.GetButtonDown(XboxButton.DPadLeft, XboxController.Fourth))
			{
				p4C = indexToLeft(p4C);
				changeCharacter(playerCharacter4, materialList[p4C]);
			}
			else if (XCI.GetButtonDown(XboxButton.DPadRight, XboxController.Fourth))
			{
				p4C = indexToRight(p4C);
				changeCharacter(playerCharacter4, materialList[p4C]);
			}
		}

	}

	void changeCharacter(GameObject c, Material nextMaterial)
	{
		c.GetComponent<Renderer>().material = nextMaterial;
	}


	void updatePosition()
	{
		// Distance moved = time * speed.
		float distCovered = (Time.time - startTime) * speed;

		// Fraction of journey completed = current distance divided by total distance.
		float fracJourney = distCovered / journeyLength;
		
		// Set our position as a fraction of the distance between the markers.
		transform.position = Vector3.Lerp(startPoint, endPoint, fracJourney);
		
	}

	void ConfirmChoice()
	{
		if (XCI.GetButtonDown(XboxButton.B, XboxController.First))
		{
			Confirm(playerCharacter1, ps1, p1C, !playerCharacter1.activeSelf);
		}
		else if (XCI.GetButtonDown(XboxButton.B, XboxController.Second))
		{
			Confirm(playerCharacter2, ps2, p2C, !playerCharacter2.activeSelf);
		}
		else if (XCI.GetButtonDown(XboxButton.B, XboxController.Third))
		{
			Confirm(playerCharacter3, ps3, p3C, !playerCharacter3.activeSelf);
		}
		else if (XCI.GetButtonDown(XboxButton.B, XboxController.Fourth))
		{
			Confirm(playerCharacter4, ps4, p4C, !playerCharacter4.activeSelf);
		}
	}

	void Confirm(GameObject player, PlayerDetails pd, int materialIndex, bool confirm)
	{
		player.transform.Find("Arrows").gameObject.SetActive(!confirm);
		player.GetComponent<Rigidbody>().useGravity = confirm;
		if (confirm)
		{
			pd = player.GetComponent<PlayerDetails>();
			pd.character = materialList[materialIndex];
			chosenList.Add(materialList[materialIndex]);
			resetMaterialList();		
		}
		else
		{
			player.transform.position = new Vector3(player.transform.position.x, characterPlacementY, player.transform.position.z);
			chosenList.Remove(materialList[materialIndex]);
			resetMaterialList();
		}
		
	}

	void resetMaterialList()
	{
		materialList = new List<Material>();
		foreach (Material m in materials)
		{
			if (!chosenList.Contains(m))
			{
				materialList.Add(m);
			}
		}
	}




}
