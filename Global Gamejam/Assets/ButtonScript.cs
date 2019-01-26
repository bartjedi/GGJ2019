using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
	[SerializeField]
	private float bottomOfScreen = -10.0f;
	[SerializeField]
	private float fallingSpeed = 0.02f;

	public GameObject gameManager;
	public GameManagerScript gms;

	// Start is called before the first frame update
	void Start()
    {
		gameManager = GameObject.Find("GameManager");
		gms = gameManager.GetComponent<GameManagerScript>();
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
}
