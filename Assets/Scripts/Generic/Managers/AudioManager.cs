using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public enum Sound
    {
        Jump,
        Switch,
    }

    [SerializeField] private AudioSource _source;
    [SerializeField] private SoundClip[] _clips;

    public static AudioManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else Destroy(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Play(Sound pSound) 
    {
        _source.PlayOneShot(GetClip(pSound));
    }

    private AudioClip GetClip(Sound pSound)
    {
        foreach(var clip in _clips)
        {
            if (pSound == clip.Sound) return clip.Clip;
        }

        return null;
    }
}

[Serializable]
public class SoundClip
{
    public AudioManager.Sound Sound;
    public AudioClip Clip; 
}
