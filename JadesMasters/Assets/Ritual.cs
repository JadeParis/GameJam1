using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEditor.Progress;

public class Ritual : MonoBehaviour
{
    public ItemStorage items;
    public List<GameObject> Candles = new List<GameObject>();
    
    public int SacraficedAmount;

   
    public void placeCandles()
    {
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
                Candles.RemoveAt(i);
            }

            if (Candles.Count == 0)
            {
                SacraficedAmount += 1;
            } 


        }
    }
    public void PlaceItems()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            placeCandles();
        }
       
    }

    public void StartRitual()
    {
       
        if(SacraficedAmount == 4)
        {
            SceneManager.LoadSceneAsync(3);
            //cut scene
        }
    }
}


