using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    private float shakeStart = float.MinValue;
    public float shakeAmount = 90f, shakeDuration = 0.5f;

    public void Shake()
    {
        shakeStart = Time.time;
    }

    private void Update()
    {
        if (Time.time < shakeStart + shakeDuration)
        {
            Vector3 euler = transform.eulerAngles;
            euler.z = Mathf.Sin((Time.time / (shakeStart + shakeDuration)) * shakeAmount);
            transform.eulerAngles = euler;
        }
        else {
            transform.eulerAngles = Vector3.zero;
        }
    }
}
