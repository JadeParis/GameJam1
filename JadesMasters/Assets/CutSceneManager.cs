using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.HID;
using UnityEngine.SceneManagement;

public class CutSceneManager : MonoBehaviour
{
    public int cutsceneTimer;
    public int loadLevelNum;
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

        SceneManager.LoadSceneAsync(loadLevelNum);
    }
    public void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
            interact = player.GetComponent<Interact>();
        else
            Debug.Log("player not found");

        if (loadLevelNum == 3)
        {
            interact.daytwo = true;
        }

    }









}
