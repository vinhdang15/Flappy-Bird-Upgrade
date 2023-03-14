using System;
using UnityEngine.Audio;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public        Sound[]        sounds;
    public static Action<string> OnPlayAudio = delegate{  };

    public void Awake()
    {
        OnPlayAudio += play;
        foreach (Sound s in sounds)
        {
            s.source        = gameObject.AddComponent<AudioSource>();
            s.source.clip   = s.clip;
            s.source.volume = s.Volume;
            s.source.pitch  = s.pitch;
        }
    }

    public void Start()
    {
        play("theme");
    }

    public void play(string name)
    {
        foreach (Sound s in sounds)
        {
            if (s.name == name)
            {
               s.source.Play();
            }
        }
    }
    
    public void OnDestroy()
    {
        OnPlayAudio -= play;
    }
}

