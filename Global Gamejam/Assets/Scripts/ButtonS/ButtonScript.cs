using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
	[SerializeField]
	private float bottomOfScreen = -10.0f;
	[SerializeField]
	private float fallingSpeed = 0.02f;
	[SerializeField]
	private Material[] materials;
    [SerializeField]
    private TextMesh textElement;

    public string English, Spanish, German, Chinese;
    

	// Start is called before the first frame update
	protected void Start()
    {
        materials = GameManagerScript.instance.materials;
        textElement = this.GetComponentInChildren<TextMesh>();
        SetColor();
        SetText();
    }

    // Update is called once per frame
    public virtual void Update()
    {
		// Button is removed when not visible anymore
		if(this.transform.position.y < bottomOfScreen)
		{
			Destroy(this.gameObject);
		}
    }

    public virtual void Trigger()
    {

    }

	public void SetColor()
	{
        int random = Random.Range(0, 4);
        Debug.Log(random);
        this.GetComponentInChildren<MeshFilter>().gameObject.GetComponent<Renderer>().material = materials[random];
	}

    public void SetText()
    {
        switch(GameManagerScript.instance.language)
        {
            case GameManagerScript.Languages.Chinese: textElement.text = Chinese; break;
            case GameManagerScript.Languages.English: textElement.text = English; break;
            case GameManagerScript.Languages.German: textElement.text = German; break;
            case GameManagerScript.Languages.Spanish: textElement.text = Spanish; break;
        }
    }
}
