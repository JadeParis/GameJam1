using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColour : MonoBehaviour
{
    public ParticleSystem targetParticleSystem; // Assign this in the Inspector
    public Color newStartColor = Color.green;
    public Interact interact;
    public void Update()
    {
        if (targetParticleSystem == null)
        {
            targetParticleSystem = GetComponent<ParticleSystem>();
        }

        if ( interact.changeColour)
        {
            var mainModule = targetParticleSystem.main;
            mainModule.startColor = newStartColor;
        }

    }

}
