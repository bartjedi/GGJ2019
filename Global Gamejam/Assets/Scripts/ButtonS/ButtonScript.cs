using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
	[SerializeField]
	private float topOfScreen;
	[SerializeField]
	private float risingSpeed = 0.05f;
	[SerializeField]
	private Material[] materials;
    private TextMesh textElement;

    public string English, Spanish, German, Chinese;
    protected void Start()
    {
        topOfScreen = Camera.main.ViewportToWorldPoint(new Vector3(0,1,15.75f)).y;
        Debug.Log(topOfScreen);
        materials = GameManagerScript.instance.materials;
        textElement = this.GetComponentInChildren<TextMesh>();
        SetColor();
        SetText();
    }

    public virtual void Update()
    {
		// Button is removed when not visible anymore
		if(this.transform.position.y > topOfScreen)
		{
            //Destroy(this.gameObject);

		}
    }

    public virtual void FixedUpdate()
    {
        this.transform.position = this.transform.position + new Vector3(0,risingSpeed,0);
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
