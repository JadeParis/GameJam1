using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoNotDestroy : MonoBehaviour
{
    private void Awake()
    {
        GameObject[] musicObj = GameObject.FindGameObjectsWithTag("GameMusic");
            if (musicObj.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
    private void Update()
    {
        // checkig to see if the current scene is in the main game scene (0)
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            // Stop the audio if it is playing 
            AudioSource audioSource = GetComponent<AudioSource>();
            if (audioSource != null && audioSource.isPlaying)
            {
                audioSource.Stop();
            }
        }
        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            AudioSource audioSource = GetComponent<AudioSource>();
            if ( audioSource != null && audioSource.isPlaying)
            {
                audioSource.Stop();
            }
        }
        if (SceneManager.GetActiveScene().buildIndex == 4)
        {
            AudioSource audioSource = GetComponent<AudioSource>();
            if (audioSource != null && audioSource.isPlaying)
            {
                audioSource.Stop();
            }
        }
    }
}
