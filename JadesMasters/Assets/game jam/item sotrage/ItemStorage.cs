using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemStorage : MonoBehaviour
{
    
   
   
    public List<string> TheList = new List<string>();
    public string myListName = ("ItemsCollected");



    public void PickUp()
    {
       
           
            Debug.Log("Added");

        Debug.Log(myListName);

    }


}
