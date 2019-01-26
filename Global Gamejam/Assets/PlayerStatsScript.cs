using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatsScript : MonoBehaviour
{
	[SerializeField]
	private int playerNr;

	private Color blue_bg = new Color(0x45, 0xaf, 0xe4);
	private Color blue_tex = new Color(0x00, 0x55, 0x93);

	private Color yellow_bg = new Color(0xfe, 0xd9, 0x40);
	private Color yellow_tex = new Color(0xa0, 0x51, 0x01);

	private Color green_bg = new Color(0x29, 0xc7, 0x6a);
	private Color green_tex = new Color(0x00, 0x5c, 0x27);

	private Color red_bg = new Color(0xff, 0x5d, 0x5a);
	private Color red_tex = new Color(0x97, 0x07, 0x03);

	private Color purple_bg = new Color(0xac, 0x8a, 0xd6);
	private Color purple_tex = new Color(0x5d, 0x34, 0x83);

	[SerializeField]
	private Sprite blueMan;
	[SerializeField]
	private Sprite yellowMan;
	[SerializeField]
	private Sprite greenMan;
	[SerializeField]
	private Sprite redMan;
	[SerializeField]
	private Sprite purpleMan;

	// Start is called before the first frame update
	void Start()
    {
        if(GameManagerScript.instance.players.Count > playerNr)
		{
			this.gameObject.SetActive(true);
			Setup();
		} 
		else
		{
			this.gameObject.SetActive(false);
		}
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	void Setup()
	{
		switch (3)
		{
			case 0:
				this.gameObject.GetComponent<Image>().color = blue_bg;
				this.GetComponentInChildren<TextMesh>().color = blue_tex;
				this.GetComponentInChildren<Image>().sprite = blueMan;
				break;
			case 1:
				this.gameObject.GetComponent<Image>().color = yellow_bg;
				this.GetComponentInChildren<TextMesh>().color = yellow_tex;
				this.GetComponentInChildren<Image>().sprite = yellowMan;
				break;
			case 2:
				this.gameObject.GetComponent<Image>().color = green_bg;
				this.GetComponentInChildren<TextMesh>().color = green_tex;
				this.GetComponentInChildren<Image>().sprite = greenMan;
				break;
			case 3:
				this.gameObject.GetComponent<Image>().color = red_bg;
				this.GetComponentInChildren<TextMesh>().color = red_tex;
				this.GetComponentInChildren<Image>().sprite = redMan;
				break;
			case 4:
				this.gameObject.GetComponent<Image>().color = purple_bg;
				this.GetComponentInChildren<TextMesh>().color = purple_tex;
				this.GetComponentInChildren<Image>().sprite = purpleMan;
				break;
			default:
				break;
		}

	}

	void UpdateStats(int lives, int total)
	{
		this.GetComponentInChildren<TextMesh>().text = lives.ToString() + "/" + total;
	}
}
