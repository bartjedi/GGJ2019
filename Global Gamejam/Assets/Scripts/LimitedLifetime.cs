using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitedLifetime : MonoBehaviour
{
    [SerializeField]
    private float timeToLive = 10f;
    private float startTime;

    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (startTime + timeToLive < Time.time)
        {
            Destroy(gameObject);
        }
    }
}
