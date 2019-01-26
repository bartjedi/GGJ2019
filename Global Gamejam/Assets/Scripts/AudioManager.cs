using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private float reverb, pitch, volume;
    [SerializeField]
    private float baseReverb, basePitch, baseVolume;
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
        pitch = basePitch;
        reverb = baseReverb;
        volume = baseVolume;
    }

    public void CrazyAudio()
    {
        pitch = Random.Range (0, 1.1f);
        volume = Random.Range (0, 1f);
        reverb = Random.Range (0, 1f);
        foreach(AudioSource audioSource in audioSources)
        {
            audioSource.pitch = pitch;
            audioSource.volume = volume;
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
            audioSource.volume = baseVolume;
            audioSource.reverbZoneMix = baseReverb;
        }
    }
}
