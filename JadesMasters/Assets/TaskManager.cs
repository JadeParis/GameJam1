using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskManager : MonoBehaviour
{
    public bool bodyTaskComplete;
    public GameObject gravetask;
    public GameObject gravecross;


    public bool diggingTaskComplete;
    public GameObject diggingtask;
    public GameObject diggingCross;

    public bool axeTaskComplete;
    public GameObject axeTask;
    public GameObject axeCross;
    public GameObject axeSprite;

    public bool chalkTaskComplete;
    public GameObject chalkTask;
    public GameObject chalkCross;

    public bool matchesTaskComplete;
    public GameObject matchesTask;
    public GameObject matchesCross;


   
    public bool cutBodyTaskComplete;
    
    public GameObject CutupBody;
    public GameObject cutBodyCross;

    public bool stealTaskComplete;
    public GameObject stealTask;
    public GameObject stealCross;

    public GameObject candlesTask;


    //Day two
    public bool DigActive;
    public bool AxeActive;
    public bool dayTwo;
    public bool steal;

    public void Start()
    {
        gravetask.SetActive(true);
        axeTask.SetActive(false);
        stealTask.SetActive(false);
        diggingtask.SetActive(false);
        chalkTask.SetActive(false);
        matchesTask.SetActive(false);
       
        candlesTask.SetActive(false);
        CutupBody.SetActive(false);
    }
    public void Update()
    {
        Done();
        DayTwo();
        Activate();
    }

    public void Activate()
    {
        if (AxeActive)
        {
            axeTask.SetActive(true);
        }
        if(DigActive)
        {
            diggingtask.SetActive(true);
        }

        if (steal)
        {
            stealTask.SetActive(true);
        }
        if (bodyTaskComplete)
        {
            gravecross.SetActive(true);
        }
        if (diggingTaskComplete)
        {
            gravecross.SetActive(true);
            diggingtask.SetActive(true);
        }
        
        
    }
    public void DayTwo()
    {
        if (dayTwo)
        {
            candlesTask.SetActive(true);
            chalkTask.SetActive(true);
            matchesTask.SetActive(true);
            //bodyTask.SetActive(true);
            CutupBody.SetActive(true);
        }
    }
    public void Done()
    {
        if(diggingTaskComplete)
        {
            diggingCross.SetActive(true);
        }
        else
        {
            diggingCross.SetActive(false);
        }
        ///////////////////////////////////////
        if(axeTaskComplete)
        {
            axeCross.SetActive(true);
            axeSprite.SetActive(true);
        }
        else
        {
            axeCross.SetActive(false);
            axeSprite.SetActive(false);
        }
        ///////////////////////////////////////
        
        if(matchesTaskComplete)
        {
            matchesCross.SetActive(true);
        }
        else
        {
            matchesCross.SetActive(false);
        }
        ///////////////////////////////////////
        if (matchesTaskComplete)
        {
            matchesCross.SetActive(true);
        }
        else
        {
            matchesCross.SetActive(false);
        }
        
        ///////////////////////////////////////////////////////
        if (cutBodyTaskComplete)
        {
            cutBodyCross.SetActive(true);
        }
        else
        {
            cutBodyCross.SetActive(false);
        }
        /////////////////////////////////
        if (stealTaskComplete)
        {
            stealCross.SetActive(true);
        }
        else
        {
            stealCross.SetActive(false);
        }

       
    }




}
