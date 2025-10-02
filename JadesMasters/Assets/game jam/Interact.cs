using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.ProBuilder;
using static UnityEditor.Progress;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Interact : MonoBehaviour
{
    public Item currentItem;
    public float distance;
    public GameObject phone;
    public GameObject phoneSprite;
    public bool phoneOn;
    public List<GameObject> myGameObjects;

    public DialogueTrigger TriggerGrave;
    public DialogueTrigger TriggerStore;
    public ItemStorage itemStore;
    
    public DialogueManager dialogueManager;
    
    // Start is called before the first frame update
    void Start()
    {
        
        myGameObjects = new List<GameObject>();
        phoneOn = false;
       
    }

    // Update is called once per frame
    void Update()
    {
        Interactable();

        if (phoneOn)
        {
            phone.SetActive(true);
            phoneSprite.SetActive(false);
        }
        else
        {
            phone.SetActive(false);
            phoneSprite.SetActive(true);
        }
    }

    public void Interactable()
    {
        RaycastHit hit;


        if (Physics.Raycast(transform.position, transform.forward, out hit, distance))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("pressed");

                if (hit.transform.CompareTag("Interactable"))
                {
                    itemStore.PickUp();
                    //GameObject.Findl("chalk").GetComponent<ItemStorage>().PickUp("Chalk", 1);
                    Debug.Log("object collected");
                    ///pick up object 

                }

                if (hit.transform.CompareTag("NPCGrave"))
                {
                    TriggerGrave.TriggerDialogue();
                    dialogueManager.grave = true;

                   
                    ///pick up object 

                }

                if (hit.transform.CompareTag("NPCStore"))
                {
                    TriggerStore.TriggerDialogue();
                    dialogueManager.steal = true;
                   
                    ///pick up object 

                }

                if (hit.transform.CompareTag("Candle"))
                {

                    //collect candle


                    Debug.Log("candle triggered");

                }

                if (hit.transform.CompareTag("Grave"))
                {
                    if (dialogueManager.grave)
                    {
                        
                        SceneManager.LoadSceneAsync(2);
                        //scene two cut scene 
                    }
                   

                }



            }

            
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.E))
            {

                if (phoneOn == false)
                {
                    
                    phoneOn = true;
                    Debug.Log("nothing");
                }

                else
                {
                  
                    phoneOn = false;
                }

            }
        }




        Debug.DrawRay(transform.position, transform.forward * distance, Color.green);

     
    }



}



