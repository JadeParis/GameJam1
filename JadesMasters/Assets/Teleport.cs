using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{

    public Interact interact;
    public PlayerInteract pinteract;

    public Transform player;

    public Transform teleportspot;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void tele()
    {
        player.transform.position = teleportspot.transform.position;
    }
    
         
}
