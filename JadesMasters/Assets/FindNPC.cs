using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindNPC : MonoBehaviour
{
    public PlayerInteract interact;
   

    public void Start()
    {
        GameObject Player = GameObject.FindGameObjectWithTag("Player");
        if (Player != null)
        {
            interact = Player.GetComponent<PlayerInteract>();
            Debug.Log("Found");


            if (interact == null)
                Debug.LogWarning("Nw");
        }
        else
        {
            Debug.LogWarning("Nw");
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
