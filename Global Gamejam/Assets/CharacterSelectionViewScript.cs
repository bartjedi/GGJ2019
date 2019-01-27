using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CharacterSelectionViewScript : MonoBehaviour
{
	[SerializeField]
	private Color notYetJoinedColor;
	[SerializeField]
	private Color yellow;
	[SerializeField]
	private Color red;
	[SerializeField]
	private Color purple;
	[SerializeField]
	private Color blue;
	[SerializeField]
	private Color green;
	[SerializeField]
	private TextMeshPro textMesh;

	public GameObject joined;
	public GameObject notjoined;


	// Start is called before the first frame update
	void Start()
    {
		this.GetComponent<SpriteRenderer>().color = notYetJoinedColor;
		notjoined.SetActive(true);
		joined.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public void Join()
	{
		SetCharacter(0);
		joined.SetActive(true);
		notjoined.SetActive(false);
	}

	public void Leave()
	{
		this.GetComponent<SpriteRenderer>().color = notYetJoinedColor;
		joined.SetActive(false);
		notjoined.SetActive(true);
	}

	public void SetCharacter(int aChar)
	{
		switch (aChar)
		{
			case 0:
				this.GetComponent<SpriteRenderer>().color = green;
				textMesh.text = "Wade";
				break;
			case 1:
				this.GetComponent<SpriteRenderer>().color = purple;
				textMesh.text = "Tobias";
				break;
			case 2:
				this.GetComponent<SpriteRenderer>().color = yellow;
				textMesh.text = "Miles";
				break;
			case 3:
				this.GetComponent<SpriteRenderer>().color = red;
				textMesh.text = "Winston";
				break;
			case 4:
				this.GetComponent<SpriteRenderer>().color = blue;
				textMesh.text = "Bjorn";
				break;
			default:
				break;
		}
	}
}
