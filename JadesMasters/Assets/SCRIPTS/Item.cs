using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class Item : MonoBehaviour
{
    public GameObject uiPopup;
    bool uiActive = false;

    private void Start()
    {
        uiPopup.SetActive(false);
    }

    public void Interact(PlayerController player)
    {
        if (uiActive) // closing ui
        {

            uiActive = false;
            player.canMove = true;
           // player.prompt.SetActive(true);
            uiPopup.SetActive(false);
        }
        else
        {

            uiActive = true;
            player.canMove = false;
            //player.prompt.SetActive(false);
            uiPopup.SetActive(true);
        }

    }
}
