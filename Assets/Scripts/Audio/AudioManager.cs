using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
/*
 AudioManager class contains all method for playing game audio. 
*/
public class AudioManager : MonoBehaviour
{
    public static AudioManager instance { get; private set; }
    public static string valueOfKeyOn { get; private set; } = "On";
    public static string valueOfKeyOff { get; private set; } = "Off";
    public static string keySoundFxPlayerPrefs = "SoundFx";
    public static string keyMusicPlayerPrefs  = "Music";

    [SerializeField]
    private Sound[] sounds;

    //calling to instantiate methods, and make this instance undestryed to have
    //the same instance in each game scene.
    private void Awake()
    {
        InstantiateInstance();
    }

    private void Start()
    {
        PlaySound(EAudioType.Background);

    }

    //Instantiate a singlton for this class, there should be one instance in the game life cycle.
    private void InstantiateInstance()
    {
        if(instance == null)
        {
            instance = this;
            InstantiateSoundsArray();
            InstantiatePlayerPrefsForAudio();


        }
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        DontDestroyOnLoad(instance);
    }

    //Instantiate array of all needed sounds for the game
    //Add new AudioSource for each sound.
    private void InstantiateSoundsArray()
    {
        foreach (Sound sound in sounds)
        {
            sound.audioSource = gameObject.AddComponent<AudioSource>();
            sound.audioSource.clip = sound.clip;
            sound.audioSource.volume = sound.volume;
            sound.audioSource.pitch = sound.pitch;
            sound.audioSource.playOnAwake = sound.playOnWake;
            sound.audioSource.loop = sound.loop;
        }
    }

    
    //This function plays sounds depends on the type is given, And check if sound is on or off
    //parameter:
    //  soundType: the type of the sound to play.
    public void PlaySound(EAudioType soundType)
    {
        if (soundType != EAudioType.Background && PlayerPrefs.GetString(keySoundFxPlayerPrefs) == valueOfKeyOff)
        {
            return;

        }else if (soundType == EAudioType.Background && PlayerPrefs.GetString(keyMusicPlayerPrefs) == valueOfKeyOff)
        {
            return;
        }

        Sound s = Array.Find(sounds,sound => sound.audioType == soundType);
        if(s == null)
        {
            Debug.LogWarning("Sound Type: " + soundType + " not found");
            return;
        }
        s.audioSource.Play();
    }

    //The function check if audio is on then switch to off, if off switch to on
    //parameters:
    //      key: key (PlayerPrfs key) as input and make the changes on this key
    public void ChangeStateForAudioByKey(string key)
    {
        
        if(key != keyMusicPlayerPrefs && key != keySoundFxPlayerPrefs)
        {
            Debug.LogWarning("Key: " + key + " not valid");
            return;
        }

        string value = PlayerPrefs.GetString(key);
        if(key == keyMusicPlayerPrefs)
        {
            if(value == valueOfKeyOff)
            {
                PlayerPrefs.SetString(key, valueOfKeyOn);
                PlaySound(EAudioType.Background);
            }
            else
            {
                PlayerPrefs.SetString(key, valueOfKeyOff);
                StopPlayingMusicSound();
            }
        }

        if(key == keySoundFxPlayerPrefs)
        {
            if(value == valueOfKeyOff)
            {
                PlayerPrefs.SetString(key, valueOfKeyOn);
            }
            else
            {
                PlayerPrefs.SetString(key, valueOfKeyOff);
            }
        }
    }

    //Check if background music is playing, if so then it stop it.
    public void StopPlayingMusicSound()
    {
        foreach (Sound sound in sounds)
        {
            if (sound.audioType == EAudioType.Background && sound.audioSource.isPlaying)
            {
                sound.audioSource.Stop();
            }
        }
    }

    //Check if PlayerPrfs keys are exist, if not it instantiate it.
    private void InstantiatePlayerPrefsForAudio()
    {
        if (!PlayerPrefs.HasKey(keySoundFxPlayerPrefs))
        {
            PlayerPrefs.SetString(keySoundFxPlayerPrefs, valueOfKeyOn);
        }

        if (!PlayerPrefs.HasKey(keyMusicPlayerPrefs))
        {
            PlayerPrefs.SetString(keyMusicPlayerPrefs, valueOfKeyOn);
        }
    }

    //Check if Audio is on (active)
    //parameeters:
    //      key: the audio key in PlayerPrefs.
    public bool IsAudioOn(string key)
    {
        if (key != keyMusicPlayerPrefs && key != keySoundFxPlayerPrefs)
        {
            throw new Exception("Key: " + key + " not valid");
        }
        string value = PlayerPrefs.GetString(key);

        return value == valueOfKeyOn;
    }

  
}
