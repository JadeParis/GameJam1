using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindNPC : MonoBehaviour
{
    public Interact interact;
   

    public void Start()
    {
        GameObject Player = GameObject.FindGameObjectWithTag("Player");
        if (Player != null)
        {
            interact = Player.GetComponent<Interact>();
            Debug.Log("Found");


            if (interact == null)
                Debug.LogWarning("NPC found but no DialogueTrigger on it!");
        }
        else
        {
            Debug.LogWarning("No NPC with tag 'NPC' found in this scene!");
        }
   
    }
    public void Update()
    {
        if (interact != null)
            interact.FindNPCS();
        else
            Debug.Log("notfound");
    }
}
