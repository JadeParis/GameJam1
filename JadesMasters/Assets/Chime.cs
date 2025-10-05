using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chime : MonoBehaviour
{
    public AudioSource chime;
    public bool playing;

    private void OnTriggerEnter(Collider other)
    {
        if (!playing)
        {
            chime.Play();
            playing = true;
        }

        
    }
    private void OnTriggerExit(Collider other)
    {
        
        playing = false;

    }
}
