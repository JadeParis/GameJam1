using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemStorage : MonoBehaviour
{
    
    public string Name;
    public int ID;
 
    
    
    
    public void PickUp(string name, int id)
    {
       
            Debug.Log($"Picked up {name} with ID {id}");
        
        
            Name = name;
            ID = id;
            
            Debug.Log("Added");
           

        
    }


}
