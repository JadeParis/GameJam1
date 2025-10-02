using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkTransition : MonoBehaviour
{

    public Animator animator;
    public ChangeScenes scenes;
    // Start is called before the first frame update
    void Start()
    {
        animator.SetBool("IsIdel", true);
       
        //StartCoroutine(Blink());
    }

    // Update is called once per frame
    void Update()
    {

       


    }
    public void StartCoro()
    {
        StartCoroutine(Blink());
    }

    public IEnumerator Blink()
    {
        //Play Animatioin here close 
        animator.SetBool("IsClose", true);
        animator.SetBool("IsOpen", false);
        animator.SetBool("IsIdel", false);
        yield return new WaitForSeconds(1); // wait for the time it takes //(this is the seconds)
        Debug.Log("heyyy");
        scenes.playing = true;
        //animation for open eyes here badabingbadaboo
        animator.SetBool("IsOpen", true);
        animator.SetBool("IsClose", false);
        //yield return new WaitForSeconds(5);
        animator.SetBool("IsIdel", true);
      
        
        StopAllCoroutines();
        
    }
}
