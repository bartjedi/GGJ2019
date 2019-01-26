using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatsScript : MonoBehaviour
{
	[SerializeField]
	private int playerNr;

	[SerializeField]
	private Color blue_bg;
	[SerializeField]
	private Color blue_tex;

	[SerializeField]
	private Color yellow_bg;
	[SerializeField]
	private Color yellow_tex;

	[SerializeField]
	private Color green_bg;
	[SerializeField]
	private Color green_tex;

	[SerializeField]
	private Color red_bg;
	[SerializeField]
	private Color red_tex;

	[SerializeField]
	private Color purple_bg;
	[SerializeField]
	private Color purple_tex;

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

    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public void Setup(int c)
	{
		this.gameObject.SetActive(true);
		switch (c)
		{
			case 0:
				this.gameObject.GetComponent<Image>().color = green_bg;
				this.GetComponentInChildren<TextMeshProUGUI>().color = green_tex;
				this.transform.Find("character").GetComponent<Image>().sprite = greenMan;
				break;
			case 1:
				this.gameObject.GetComponent<Image>().color = purple_bg;
				this.GetComponentInChildren<TextMeshProUGUI>().faceColor = purple_tex;
				this.transform.Find("character").GetComponent<Image>().sprite = purpleMan;
				break;
			case 2:
				this.gameObject.GetComponent<Image>().color = yellow_bg;
				this.GetComponentInChildren<TextMeshProUGUI>().color = yellow_tex;
				this.transform.Find("character").GetComponent<Image>().sprite = yellowMan;
				break;
			case 3:
				this.gameObject.GetComponent<Image>().color = red_bg;
				this.GetComponentInChildren<TextMeshProUGUI>().color = red_tex;
				this.transform.Find("character").GetComponent<Image>().sprite = redMan;
				break;
			case 4:
				this.gameObject.GetComponent<Image>().color = blue_bg;
				this.GetComponentInChildren<TextMeshProUGUI>().color = blue_tex;
				this.transform.Find("character").GetComponent<Image>().sprite = blueMan;
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
