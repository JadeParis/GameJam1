using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCLock : MonoBehaviour
{

    public Vector3 NPCTalkingPos = new Vector3(393.6f, 286.88f, 70.1445f);
   
    Quaternion NPCTalkingRotation = Quaternion.Euler(0f, 205.35f, 0f);

    public bool talking;
    public Transform player;
    public PlayerController playerController;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (talking)
        {
            player.transform.position = NPCTalkingPos;
            player.transform.rotation = NPCTalkingRotation;

            playerController.canMove = false;
        }
        if (!talking)
        {
            playerController.canMove = false;  
        }
    }
}
