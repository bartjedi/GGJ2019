using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private float reverb, pitch;
    [SerializeField]
    private float baseReverb, basePitch;
    [SerializeField]
    private AudioSource[] audioSources;
    [SerializeField]
    private int resetAudioTimer;


    public static AudioManager instance = null;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            if (instance != this)
            {
                Destroy(gameObject);
            }
        }
    }

    private void Start()
    {
        basePitch = audioSources[0].pitch;
        baseReverb = audioSources[0].reverbZoneMix;
    }

    public void CrazyAudio()
    {
        pitch = Random.Range (-3f, 3f);
        reverb = Random.Range (0, 1f);
        foreach(AudioSource audioSource in audioSources)
        {
            audioSource.pitch = pitch;
            audioSource.reverbZoneMix = reverb;
        }
        StartCoroutine(ResetAudio());
    }

    IEnumerator ResetAudio()
    {
        yield return new WaitForSeconds(resetAudioTimer);
        foreach (AudioSource audioSource in audioSources)
        {
            audioSource.pitch = basePitch;
            audioSource.reverbZoneMix = baseReverb;
        }
    }
}
