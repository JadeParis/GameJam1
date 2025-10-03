using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.HID;
using UnityEngine.SceneManagement;

public class CutSceneManager : MonoBehaviour
{
    public int cutsceneTimer;
    public int loadLevelNum;
    public void Start()
    {
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        //audio here!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        yield return new WaitForSeconds(cutsceneTimer);

        SceneManager.LoadSceneAsync(loadLevelNum);
    }
               
              
          



      

    
}
