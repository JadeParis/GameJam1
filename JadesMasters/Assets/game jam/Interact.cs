using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.ProBuilder;
using static UnityEditor.Progress;

public class Interact : MonoBehaviour
{
    public Item currentItem;
    public float distance;
    public GameObject phone;
    public bool phoneOn;
    public List<GameObject> myGameObjects;

    public ItemStorage itemStore;
    // Start is called before the first frame update
    void Start()
    {
        phone.SetActive(false);
        myGameObjects = new List<GameObject>();
        phoneOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

       

        if (Physics.Raycast(transform.position, transform.forward, out hit, distance))
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Debug.Log("pressed");

                    if (hit.transform.CompareTag("Interactable"))
                    {

                        //GameObject.Findl("chalk").GetComponent<ItemStorage>().PickUp("Chalk", 1);
                        Debug.Log("object collected");
                        ///pick up object 
                    

                    }
                   
                

                }

                //if (hit.collider.GetComponent<Item>() != null && currentItem == null)
                //{
                //    //prompt.SetActive(true);
                //    currentItem = hit.collider.GetComponent<Item>();
                //}
                //else
                //{
                ////prompt.SetActive(false);
                //currentItem = null;
            }
            else
            {
                if(Input.GetKeyDown(KeyCode.E))
                {
                    
                        if (phoneOn == false)
                        {
                            phone.SetActive(true);
                            phoneOn = true;
                            Debug.Log("nothing");
                        }

                        else
                        {
                            phone.SetActive(false);
                            phoneOn = false;
                        }
                    
                }
            }

         
         

        


        Debug.DrawRay(transform.position, transform.forward * distance, Color.green);

        //if (phoneOn == true)
        //{
        //    phone.SetActive(false);
        //    phoneOn = false;
        //}
    }

                   



    }



