using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.ProBuilder;
using static UnityEditor.Progress;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

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
    public ItemStorage itemStore;
    
    public DialogueManager dialogueManager;

    public GameObject chalkCross;
    public GameObject matchesCross;
    public GameObject bodyCross;
    public GameObject axeCross;
    public GameObject axeSprite;
    public GameObject axetask;
    public GameObject axe;
    public bool axeCollected;

    //Candle Collection
    public GameObject candlesCross;
    public bool CandleCollected;

    public DialogueManager dialogue;
    public ItemStorage items;
    // Start is called before the first frame update
    void Start()
    {
        candleListMade = false;
        candleScore = 0;
        myGameObjects = new List<GameObject>();
        phoneOn = false;
        allowPhone = true;
        CandleCollected = false;
        axeSprite.SetActive(false);
        axetask.SetActive(false);
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
    public int candleScore;
    public bool candleListMade;
    public void Interactable()
    {
        RaycastHit hit;


        if (Physics.Raycast(transform.position, transform.forward, out hit, distance))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("pressed");
                phoneOn = false;

                if (hit.transform.CompareTag("NPCGrave"))
                {
                    allowPhone = false;
                    TriggerGrave.TriggerDialogue();

                    dialogueManager.grave = true;

                    axetask.SetActive(true);
                    axe.SetActive(true);

                    ///pick up object 

                }

                if (hit.transform.CompareTag("NPCStore"))
                {
                    allowPhone = false;
                    TriggerStore.TriggerDialogue();
                    dialogueManager.steal = true;

                    ///pick up object 
                    ///


                }

                if (hit.transform.CompareTag("Candle"))
                {
                    candleScore += 1;
                    //collect candle

                    Destroy(hit.collider.gameObject);

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

                if (hit.transform.CompareTag("Grave"))
                {
                    if (dialogueManager.grave && axeCollected)
                    {
                        bodyCross.SetActive(true);
                        SceneManager.LoadSceneAsync(2);
                        //scene two cut scene 
                    }



                }

                if (hit.transform.CompareTag("Chalk"))
                {

                    Destroy(hit.collider.gameObject);
                    chalkCross.SetActive(true);
                    //scene two cut scene 

                }

                if (hit.transform.CompareTag("Matches"))
                {

                    Destroy(hit.collider.gameObject);
                    matchesCross.SetActive(true);

                    InventoryInfo matches = new InventoryInfo();
                    matches.Name = "Mathces";
                    items.collected.Add(matches);
                    matches.Quantity = 1;
                    //items.PickUp("Laptop", 1);
                }

                if (hit.transform.CompareTag("Laptop"))
                {
                    allowPhone = false;



                    ///pick up object 

                }

                if (hit.transform.CompareTag("Axe"))
                {

                    Destroy(hit.collider.gameObject);
                    axeCross.SetActive(true);
                    //scene two cut scene 
                    axeSprite.SetActive(true);
                    axeCollected = true;


                    InventoryInfo axe = new InventoryInfo();
                    axe.Name = "Axe";
                    items.collected.Add(axe);
                    axe.Quantity = 1;


                    


                }



            }

            else
            {
                if (Input.GetKeyDown(KeyCode.Tab))
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



}



