using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanguageButtonScript : ButtonScript
{
	//private List<string> buttonText = ["Select Language", "Seleccione el idioma", "Sprache Auswählen", "选择语言"];

    // Start is called before the first frame update
    void Start()
    {
		//this.transform.Find("ButtonText").gameObject.GetComponent<TextMesh>().text = buttonText[gms.language];
    }

    // Update is called once per frame
    void Update()
    {
		base.Update();
	}

	void Function()
	{
		//gms.language = Random.Range(0, buttonText.Count);
	}
}
