using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UIElements;
using static Unity.VisualScripting.Member;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public Sound[] sfxLibary;
    public Sound[] musicLibary;
    AudioSource musicSource;

    [Range(0f, 1f)]
    public float sfxVolume;


    [Range (0f, 1f)]
    public float musicVolume;

    public AudioMixerGroup sfxMixer;
    public AudioMixerGroup musicMixer;
    public void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(gameObject);

        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        foreach(Sound s in sfxLibary)
        {
            s.source = gameObject.AddComponent<AudioSource>();

            s.source.clip = s.clip;
            s.source.loop = s.loop;
            s.source.volume = s.maxVolume * sfxVolume;

            s.source.playOnAwake = false;

            s.source.outputAudioMixerGroup = sfxMixer;
     

        }

        musicSource = gameObject.AddComponent<AudioSource>();
        musicSource.outputAudioMixerGroup = musicMixer;

        musicSource.playOnAwake=false;

    }

    public void PlaySFX(string name)
    {
        Sound s = FindSound(sfxLibary, name);
        
        if (s.source.isPlaying)
        {
            return;
        }

        s.source.Play();

      
    }

    public void PlayMusic(string name)
    {
        Sound s = FindSound(musicLibary, name);

        s.source.clip = s.clip;
        s.source.loop = s.loop;
        s.source.volume = s.maxVolume * musicVolume;

        if (s == null)
        {
            Debug.Log("NoSound");
        }

        s.source.Play();
    }


     Sound FindSound(Sound[] libary, string name)
      {
            Sound s = Array.Find(libary, sound => sound.name == name);

            if (s == null)
            {
                Debug.LogError("npSound Found Of That Name");

            }

            
                return s;
            


     }
    
    public void StopSFX(string name)
    {
        Sound s = Array.Find(sfxLibary, sound => sound.name == name);

      

        if (s == null)
        {
            Debug.LogError("npSound Found Of That Name");

        }

        if (!s.source.isPlaying)
        {
            return;
        }

        s.source.Stop();
    }




    [System.Serializable]

    public class Sound 
    { 
    
        public string name; // ID --- HOW WE REFERENCE OUR SOUND
        public AudioClip clip;

        [Range(0f, 1f)]
        public float maxVolume;

        public bool loop;
        [HideInInspector] public AudioSource source;
    }


}
