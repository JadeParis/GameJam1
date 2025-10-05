using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cutscenemanagerend : MonoBehaviour
{

    public int cutsceneTimer;
    
    public Interact interact;


    public void Start()
    {


        StopAllCoroutines();
        StartCoroutine(Wait());

    }

    IEnumerator Wait()
    {
        //audio here!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        yield return new WaitForSeconds(cutsceneTimer);

        Application.Quit();
    }
   

}
