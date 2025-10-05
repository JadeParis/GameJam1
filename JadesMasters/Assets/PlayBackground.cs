using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayBackground : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioSource audioSource2;
    public AudioSource audioSource3;


    void Start()
    {
        // Get the AudioSource component attached to this GameObject
        audioSource = GetComponent<AudioSource>();
        audioSource2 = GetComponent<AudioSource>();
        audioSource3 = GetComponent<AudioSource>();

        PlaySound();
    }

    // Call this method to play the sound
    public void PlaySound()
    {
        if (audioSource != null && audioSource.clip != null)
        {
            audioSource.Play();
            audioSource2.Play();
            audioSource3.Play();
        }
        else
        {
            Debug.LogWarning("AudioSource or AudioClip not assigned!");
        }
    }

 
    
}

