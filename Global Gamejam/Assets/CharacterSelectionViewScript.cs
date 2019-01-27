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

	private GameObject joined;
	private GameObject notjoined;


	// Start is called before the first frame update
	void Start()
    {
		this.GetComponent<SpriteRenderer>().color = notYetJoinedColor;
		notjoined = GameObject.Find("WaitForJoin");
		joined = GameObject.Find("ChoseCharacter");
		notjoined.SetActive(true);
		joined.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public void Join()
	{
		joined.SetActive(true);
		notjoined.SetActive(false);
	}

	public void Leave()
	{
		joined.SetActive(false);
		notjoined.SetActive(true);
	}

	public void SetCharacter(int aChar)
	{
		switch (aChar)
		{
			case 0:
				this.GetComponent<SpriteRenderer>().color = green;
				this.transform.Find("Name").GetComponent<TextMeshPro>().text = "Wade";
				break;
			case 1:
				this.GetComponent<SpriteRenderer>().color = purple;
				this.transform.Find("Name").GetComponent<TextMeshPro>().text = "Tobias";
				break;
			case 2:
				this.GetComponent<SpriteRenderer>().color = yellow;
				this.transform.Find("Name").GetComponent<TextMeshPro>().text = "Miles";
				break;
			case 3:
				this.GetComponent<SpriteRenderer>().color = red;
				this.transform.Find("Name").GetComponent<TextMeshPro>().text = "Winston";
				break;
			case 4:
				this.GetComponent<SpriteRenderer>().color = blue;
				this.transform.Find("Name").GetComponent<TextMeshPro>().text = "Bjorn";
				break;
			default:
				break;
		}
	}
}
