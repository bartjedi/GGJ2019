using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credits : ButtonScript
{
	[SerializeField]
	private string[] names;
	[SerializeField]
	CreditsButton creditsButton;

	override public void Trigger(GameObject player)
	{
        StartCoroutine(SpawnCredits());
        ps.Play();
        Camera.main.GetComponent<CameraShake>().Shake();
	}

    IEnumerator SpawnCredits()
    {
        for (int i = 0; i < names.Length; i++)
        {
            CreditsButton cb = Instantiate(creditsButton, new Vector3(Camera.main.ViewportToWorldPoint(new Vector2(Random.value, 0)).x, Camera.main.ViewportToWorldPoint(new Vector2(0, 1)).y, 0), creditsButton.transform.rotation);
            cb.SetText(names[i]);
            yield return new WaitForSeconds(1); 
        }
    }
}
