using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.ProBuilder;
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

    public bool Done1;
    public bool Done2;
    public bool Done3;
    public bool Done4;
    public GameObject candelUI;
    public void Start()
    {
        candelUI.SetActive(true);
        Chalk.SetActive(false);
    }
    private void Update()
    {
        
       
        
    }
    public void placeCandles()
    {
        Debug.Log("PlaceCandles");
        InventoryInfo candle = items.collected.Find(i => i.Name == "Candle");
       

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
            bool allCandlesActive = Candles.All(c => c.activeSelf);

            if (allCandlesActive)
            {
                if (!Done4)
                {
                    SacraficedAmount += 1;
                    Done4= true;
                    candelUI.SetActive(false);
                }

           
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
                if (!Done1)
                {
                    SacraficedAmount += 1;
                    Done1 = true;
                }
               
             
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

            if (!Done2)
            {
                SacraficedAmount += 1;
                Done2 = true;
            }
               
           // }
           // else
            //{
               // Debug.Log("noBody");
           // }
        }

        if(targetChalk != null) 
        {

            Chalk.SetActive(true);
            if (!Done3)
            {
                SacraficedAmount += 1;
                Done3 = true;
            }

            ////////////////////////////////Audio herreee!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!


        }

        if (SacraficedAmount == 4)
        {

            StartCoroutine(Wait());
            //camera shake in here pan to ground camera 
        
            //cut scene
        }

    }


    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(4);
        SceneManager.LoadSceneAsync(4);

       
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


