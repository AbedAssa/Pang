using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Sound class holding data for creating new AudioSource component
[System.Serializable]
public class Sound
{
    public EAudioType audioType;
    public AudioClip clip;
    [Range(0f,1f)]
    public float volume = 0.5f;
    [Range(0.1f, 3f)]
    public float pitch = 1f;
    [HideInInspector]
    public AudioSource audioSource;
    public bool playOnWake;
    public bool loop;
}
