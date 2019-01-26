using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuInteractions : MonoBehaviour
{
    // put the first material here.
    public Material regularMaterial;
    // put the second material here.
    public Material ClickedMaterial;
    public bool Clicked = false;
    void Start()
    {
        Debug.Log("load YEAH");
        GetComponent<Renderer>().material = regularMaterial;
    }

    void OnMouseDown()
    {
        Clicked = true;
        GetComponent<Renderer>().material = ClickedMaterial;
     
    }
    void OnMouseUp()
    {
        Clicked = false;
        GetComponent<Renderer>().material = regularMaterial;

    }
}
