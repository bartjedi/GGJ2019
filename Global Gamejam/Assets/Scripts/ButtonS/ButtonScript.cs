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
    private TextMesh textElement;

    public string English, Spanish, German, Chinese;
    
	protected void Start()
    {
        materials = GameManagerScript.instance.materials;
        textElement = this.GetComponentInChildren<TextMesh>();
        SetColor();
        SetText();
    }

    public virtual void Update()
    {
		// Button is removed when not visible anymore
		if(this.transform.position.y < bottomOfScreen)
		{
			Destroy(this.gameObject);
		}
    }

    /// <summary>
    ///  occurs on ground pound
    /// </summary>
    public virtual void Trigger()
    {

    }

    /// <summary>
    /// occurs on any random jump
    /// </summary>
    public virtual void Jumped()
    {

    }


    public void SetColor()
	{
        int random = Random.Range(0, 4);
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
