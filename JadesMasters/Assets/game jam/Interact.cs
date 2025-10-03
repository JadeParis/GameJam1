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

    //Candle Collection
    public GameObject candlesCross;
    public bool CandleCollected;

    public DialogueManager dialogue;

    // Start is called before the first frame update
    void Start()
    {
        candleScore = 0;
        myGameObjects = new List<GameObject>();
        phoneOn = false;
        allowPhone = true;
        CandleCollected = false;
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
    public void Interactable()
    {
        RaycastHit hit;


        if (Physics.Raycast(transform.position, transform.forward, out hit, distance))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("pressed");
                phoneOn = false;
                

                if (hit.transform.CompareTag("Interactable") && !phoneOn)
                {
                    itemStore.PickUp();
                    //GameObject.Findl("chalk").GetComponent<ItemStorage>().PickUp("Chalk", 1);
                    Debug.Log("object collected");
                    ///pick up object 
                    ///

                }

                if (hit.transform.CompareTag("NPCGrave"))
                {
                    allowPhone = false;
                    TriggerGrave.TriggerDialogue();
                       
                        dialogueManager.grave = true;

                 
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
                        candlesCross.SetActive (true);
                    }
                    Debug.Log("candle triggered");

                   
                }

                if (hit.transform.CompareTag("Grave"))
                {
                    if (dialogueManager.grave)
                    {
                        bodyCross.SetActive(true);
                        SceneManager.LoadSceneAsync(2);
                        //scene two cut scene 
                    }

                   

                }

                if (hit.transform.CompareTag("Chalk"))
                {
                    if (dialogueManager.grave)
                    {

                        chalkCross.SetActive(true);
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



