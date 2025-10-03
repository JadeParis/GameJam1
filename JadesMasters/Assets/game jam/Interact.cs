using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.ProBuilder;
using static UnityEditor.Progress;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using System.Linq;
using System;
using Unity.Collections;

public class Interact : MonoBehaviour
{
    public Item currentItem;
    public float distance;
    public GameObject phone;
    public GameObject phoneSprite;
    public GameObject UIphone;
    public bool phoneOn;
    public bool allowPhone;
    public List<GameObject> myGameObjects;

    public DialogueTrigger TriggerGrave;
    public DialogueTrigger TriggerStore;
    public DialogueTrigger TriggerCreep;
    public ItemStorage itemStore;

    public ShakePhone shake;

    public GameObject candleHolder;
    public DialogueManager dialogueManager;

    //public GameObject chalkCross;
    //public GameObject matchesCross;
    //public GameObject bodyCross;
    //public GameObject axeCross;
    //public GameObject axeSprite;
    //public GameObject axetask;

    public GameObject reddit;
    public GameObject axe;
    public bool axeCollected;

    //Candle Collection
    public GameObject candlesCross;
    public bool CandleCollected;


    //scripts 
    public DialogueManager dialogue;
    public ItemStorage items;
    public Ritual ritual;
    public TaskManager taskManager;

    public int candleScore;
    public bool candleListMade;
    public GameObject chalk;

    public bool daytwo;
    // Start is called before the first frame update
    void Start()
    {

        player.transform.localPosition = StartingPoint.transform.position;
        player.rotation = StartingPoint.transform.rotation;
        chalk.SetActive(false);
        reddit.SetActive(false);
        candleListMade = false;
        candleScore = 0;
        myGameObjects = new List<GameObject>();
        phoneOn = false;
        allowPhone = true;
        CandleCollected = false;
        taskManager.axeSprite.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        Interactable();
        Phone();


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
        if(allowPhone)
        {
            UIphone.SetActive(true);
        }
        else
        {
            UIphone.SetActive(false);
            phoneSprite.SetActive(false);
        }

        
    }
    public Transform player;
    public Transform StartingPoint;
    public bool talking;
    public void Interactable()
    {
        RaycastHit hit;


        if (Physics.Raycast(transform.position, transform.forward, out hit, distance))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                //collect audio here!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

                Debug.Log("pressed");
                phoneOn = false;

                if (hit.transform.CompareTag("NPCGrave"))
                {

                    allowPhone = false;
                  
                    
                    taskManager.bodyTaskComplete = true;
                    dialogueManager.grave = true;

                    taskManager.AxeActive = true;
                    taskManager.DigActive = true;
                    axe.SetActive(true);
                    if (!talking)
                    {
                        TriggerGrave.TriggerDialogue();
                        talking = true;
                    }
                    
                    ///pick up object 

                }

                if (hit.transform.CompareTag("Grave"))
                {
                    if (dialogueManager.grave && axeCollected)
                    {
                        
                        SceneManager.LoadSceneAsync(2);
                        
                        player.transform.localPosition = StartingPoint.transform.position;
                        player.rotation = StartingPoint.transform.rotation;
                        
                        taskManager.dayTwo = true;
                        daytwo = true;
                        //scene two cut scene 
                    }



                }

                if (hit.transform.CompareTag("Axe"))
                {
                    taskManager.axeTaskComplete = true;
                    //scene two cut scene 
                    
                    axeCollected = true;

                    InventoryInfo axe = new InventoryInfo();
                    axe.Name = "Axe";
                    items.collected.Add(axe);
                    axe.Quantity = 1;
                    axe.GameObject = hit.collider.gameObject;
                    hit.collider.gameObject.SetActive(false);

                }

                /////////day one ^^^^^^^^^^^^^^^^^^^^^^^^^^
                if (hit.transform.CompareTag("NPCStore"))
                {
                    if (!talking)
                    {
                        TriggerStore.TriggerDialogue();
                        talking = true;
                    }
                    allowPhone = false;
                    
                    
                    if (daytwo)
                    {
                        chalk.SetActive(true);
                        dialogueManager.steal = true;

                        taskManager.steal = true;

                        shake.Shake();

                        //set matches true
                    }
                    
                   

                }

                if (hit.transform.CompareTag("NPCCreep"))
                {
                    allowPhone = false;
                    if (!talking)
                    {
                        TriggerCreep.TriggerDialogue();
                        talking = true;
                    }


                    if (daytwo)
                    {
                        chalk.SetActive(true);
                    }
                  
                    //PHONE SHAKE 
                    ///pick up object 
                    ///


                }

                if (hit.transform.CompareTag("Candle"))
                {
                    if (!daytwo)
                    {
                        candleHolder.SetActive(false);
                    }
                    candleScore += 1;
                    //collect candle

                    hit.collider.gameObject.SetActive(false);

                    if (candleScore == 5)
                    {
                        candlesCross.SetActive(true);
                    }
                    Debug.Log("candle triggered");

                    
                    if (candleListMade)
                    {

                        InventoryInfo candle = items.collected.Find(i => i.Name == "Candle");
                        candle.Quantity += 1;
                    }
                    else
                    {
                        InventoryInfo candle = new InventoryInfo();
                        candle.Name = "Candle";
                        items.collected.Add(candle);
                        candle.Quantity = 1;
                        candleListMade = true;
                    }

                }

                

                if (hit.transform.CompareTag("Chalk"))
                {
                    taskManager.chalkTaskComplete = true;
                  
                    //scene two cut scene 

                    //////// ADD REF TO NPC MAD HERE!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                    InventoryInfo chalk = new InventoryInfo();
                    chalk.Name = "Chalk";
                    items.collected.Add(chalk);
                    chalk.Quantity = 1;
                    chalk.GameObject = hit.collider.gameObject;

                    hit.collider.gameObject.SetActive(false);
                    //items.PickUp("Laptop", 1);
                }

                if (hit.transform.CompareTag("Matches"))
                {
                    taskManager.matchesTaskComplete = true;
                    InventoryInfo matches = new InventoryInfo();
                    matches.Name = "Matches";
                    items.collected.Add(matches);
                    matches.Quantity = 1;
                    //matches.GameObject = hit.collider.gameObject;
                    //turn off 
                    hit.collider.gameObject.SetActive(false);
                    


                }


              

                if (hit.transform.CompareTag("Body"))
                {
                    //add a cross task to this 
                    

                    InventoryInfo body = new InventoryInfo();
                    body.Name = "Body";
                    items.collected.Add(body);
                    body.Quantity = 1;
                    body.GameObject = hit.collider.gameObject;
                    hit.collider.gameObject.SetActive(false);
                    taskManager.cutBodyTaskComplete = true;
                    StopAllCoroutines();
                    StartCoroutine(Wait());

                }


                ////Check Laptop Screen Start

                if (hit.transform.CompareTag("Laptop"))
                {

                    if (!Screenup) // If laptop is CLOSED -> open it
                    {
                        allowPhone = false;
                        reddit.SetActive(true);
                        Flashing.SetActive(true);
                        Screenup = true;
                        
                    }

                    else // If laptop is OPEN -> close it
                    {
                        reddit.SetActive(false);
                        Flashing.SetActive(false);
                        allowPhone = true;
                        Screenup = false;

                        shake.shakestart();
                    }


                   
                    ///pick up object 

                }

                if (hit.transform.CompareTag("RitualSpot"))
                {

                    ritual.placeCandles();
                    ritual.PlaceItems();

                    ///pick up object 

                }


            }


           




            Debug.DrawRay(transform.position, transform.forward * distance, Color.green);


        }
    }

    public GameObject Flashing;
    public bool Screenup;
    public void Phone()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Debug.Log("TabPressed");

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

    IEnumerator Wait()
    {
        //audio here!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        yield return new WaitForSeconds(4);
    }

  

}



