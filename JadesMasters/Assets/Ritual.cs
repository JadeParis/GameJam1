using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.ProBuilder.MeshOperations;
using UnityEngine.SceneManagement;
using static UnityEditor.Progress;

public class Ritual : MonoBehaviour
{
    public ItemStorage items;
    public List<GameObject> Candles = new List<GameObject>();
    
    public int SacraficedAmount;

    public GameObject Body;
    public ItemStorage stored;

    public GameObject Chalk;

    public bool hasMatches;
    public bool hasBody;
    public bool hasChalk;

    public void Start()
    {

        Chalk.SetActive(false);
    }
    private void Update()
    {
        
       
        
    }
    public void placeCandles()
    {
        Debug.Log("PlaceCandles");
        InventoryInfo candle = items.collected.Find(i => i.Name == "Candle");
        bool allCandlesActive = Candles.All(c => c.activeSelf);

        if (candle != null)
        {
            // First, disable all candles
            foreach (GameObject go in Candles)
            {
                go.SetActive(false);
            }


            int index = Candles.Count + 1;

            for (int i = 0; i < candle.Quantity && i < Candles.Count; i++)
            {
                Candles[i].SetActive(true);
                //Candles.RemoveAt(i);
            }

            //if (Candles.Count == 0)
            //{
            //    SacraficedAmount += 1;
            //} 

            if (allCandlesActive)
            {
                SacraficedAmount += 1;
            }

        }
    }

    public void PlaceItems()
    {
        Debug.Log("PlaceItem");
        string targetName = "Matches"; // look for this name 

        
       

        Debug.Log("PlaceCandles");
        InventoryInfo targetBody = items.collected.Find(i => i.Name == "Body");
        

        InventoryInfo targetChalk = items.collected.Find(i => i.Name == "Chalk");
       

        // making a bool if it has matches 
        bool hasMatches = stored.collected.Any(item => item.Name == targetName);
       

        foreach (GameObject candle in Candles)
        {
           

            if (candle.activeSelf)
            {
               
                if (hasMatches) // if it does 
                {
                    candle.transform.GetChild(0).gameObject.SetActive(true);


                }
                else
                {
                    Debug.Log("no candles or matches");
                }


            }

            //Check to see if all candles are lit
            bool allChildrenActive = true;

            for (int i = 0; i < candle.transform.childCount; i++)
            {
                if (!candle.transform.GetChild(i).gameObject.activeSelf)
                {
                    allChildrenActive = false;
                    break; // no need to check the rest
                }
            }

            if (allChildrenActive)
            {
                Debug.Log(candle.name + " has all children active!");
                SacraficedAmount += 1;
             
            }
            else
            {
                Debug.Log(candle.name + " does NOT have all children active.");
            }
        }

    

        if (targetBody != null)
        {
            //InventoryInfo item = stored.collected.FirstOrDefault(i => i.Name == targetBody);
            //if (item != null && item.GameObject != null)
            //{
            //    ////////////////////////////////////////////////////////////Audio Here thump 

                Body.SetActive(true);
                
                SacraficedAmount += 1;
           // }
           // else
            //{
               // Debug.Log("noBody");
           // }
        }

        if(targetChalk != null) 
        {

            Chalk.SetActive(true);
            SacraficedAmount += 1;
            ////////////////////////////////Audio herreee!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!


        }

        if (SacraficedAmount == 4)
        {
            //camera shake in here pan to ground camera 
            SceneManager.LoadSceneAsync(4);
            //cut scene
        }

    }

 
        
                //  for (int i = 0; i<stored.collected.Count; i++)
                //                {
                //                    if (stored.collected[i].Name == targetName)
                //                    {
                //                        candle.transform.GetChild(i).gameObject.SetActive(true);
                //                        // Works here, because i is in scope

                //                    }
                //                    else
                //{
                //    return;
                //}
                //                }

   

    public void StartRitual()
    {
       
        if(SacraficedAmount == 4)
        {
            //camera shake in here pan to ground camera 
            SceneManager.LoadSceneAsync(4);
            //cut scene
        }
    }
}


