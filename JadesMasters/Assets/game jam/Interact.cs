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
using UnityEngine.InputSystem.HID;

public class Interact : MonoBehaviour
{
   
    public float distance;
    public GameObject phone;
    public GameObject phoneSprite;
    public GameObject UIphone;
    public bool phoneOn;
    public bool allowPhone;
    public List<GameObject> myGameObjects;
    public GameObject deadBody;
  
    public GameObject candleHolder;
 
    public GameObject laptop;

    public Transform player;
    public Transform StartingPoint;
    public Transform StartingPoint2;

    public bool daytwoevents;
   
    public GameObject reddit;
    public GameObject axe;
    

    //Candle Collection
   
    public bool CandleCollected;

    public GameObject creep;
    //scripts 
    
    
    
    public TaskManager taskManager;

    public int candleScore;
    public bool candleListMade;
   
    public bool daytwo;
    public Fade fade;
    public GameObject grave;


    public bool phoneintro;
    public GameObject Menu;

    // Start is called before the first frame update
    void Start()
    {
        ///FindNPCS();
      
       
        
         player.transform.localPosition = StartingPoint.transform.position;
         player.rotation = StartingPoint.transform.rotation;
        

        candleHolder.SetActive(false);
        reddit.SetActive(false);
        // phoneSprite.SetActive(false);
        laptop.SetActive(true);
        axe.SetActive(false);
        deadBody.SetActive(false);
        creep.SetActive(false);
        candleListMade = false;
        candleScore = 0;
        myGameObjects = new List<GameObject>();
        phoneSprite.SetActive(false);
        allowPhone = false;
        CandleCollected = false;
        taskManager.axeSprite.SetActive(false);
        phoneOn = false;
       
    }
   
    // Update is called once per frame
    void Update()
    {
        
        Phone();
       

        if (phoneintro)
        {
            Menu.SetActive(true);
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
        else
        {
            Menu.SetActive(false);
        }

        if (allowPhone)
        {
            UIphone.SetActive(true);

            // phoneSprite.SetActive(false);
        }
        else
        {
            UIphone.SetActive(false);
            //phoneSprite.SetActive(false);
        }

        if (daytwo)
        {
            phoneintro = true;
            
            allowPhone = true;
            laptop.SetActive(false);
            deadBody.SetActive(true);
            daytwoevents = true;

                player.transform.localPosition = StartingPoint2.transform.position;
                player.rotation = StartingPoint2.transform.rotation;
            
            if (creep != null)
            {
                creep.SetActive(true);
            }

            grave.SetActive(false);

            daytwo = false;
            candleHolder.SetActive(true );
        }

      

    }

   
    
  
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

    public IEnumerator Wait()
    {
        //audio here!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        yield return new WaitForSeconds(4);
        fade.HideUI();
        Debug.Log("made it!");
        yield return new WaitForSeconds(1);
        StopAllCoroutines();
    }

  

}



