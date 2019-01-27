using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScreenButtonEffects : MonoBehaviour
{
    public Material[] materials;

    private void Awake ()
    {
        Vector3 rot = new Vector3(Random.value * 360f, Random.value * 360f, Random.value * 360f);
        transform.eulerAngles = rot;

        if (materials.Length > 0)
        {
            int random = Random.Range(0, materials.Length);
            GetComponent<MeshRenderer>().material = materials[random];
        }
    }
}
