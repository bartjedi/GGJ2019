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

	// Start is called before the first frame update
	protected void Start()
    {
        materials = GameManagerScript.instance.materials;
        SetColor();
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

	public void SetColor()
	{
        int random = Random.Range(0, 4);
        Debug.Log(random);
        this.GetComponentInChildren<MeshFilter>().gameObject.GetComponent<Renderer>().material = materials[random];
	}
}
