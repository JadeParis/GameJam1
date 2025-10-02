using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ChangeScenes : MonoBehaviour
{
    [SerializeField] public BlinkTransition blink;
    public bool playing;
    public int sceneID;

    public void Update()
    {
        if (playing)
        {
            byeee(sceneID);
            //SceneManager.LoadScene(sceneID);
            playing = false;
        }
        else
        {

        }
    }
    public void MoveToScene()
    {

        blink.StartCoro();
        
    }

   public void byeee(int sceneID)
   {
        SceneManager.LoadScene(sceneID);
   }
}
