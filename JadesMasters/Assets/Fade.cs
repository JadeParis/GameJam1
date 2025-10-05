using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade: MonoBehaviour
{
    [SerializeField] private CanvasGroup myUIGroup;
    // Start is called before the first frame update

    [SerializeField] private bool fadeIn = false;
    [SerializeField] private bool fadeOut = false;
    public GameObject UI;


    public void ShowUI()
    {
       fadeIn = true;
        UI.SetActive(false);
    }

    public void HideUI()
    {
        fadeOut = false;
        fadeIn = false;
        UI.SetActive(true);
    }

    private void Update()
    {
        if(fadeIn)
        {
            if(myUIGroup.alpha < 1)
            {
                myUIGroup.alpha += Time.deltaTime;

                if(myUIGroup.alpha >= 1)
                {
                    fadeIn = true;
                   
                    fadeOut = false;
                }
            }
        }

        else
        {
            if (myUIGroup.alpha >= 0)
            {
                myUIGroup.alpha -= Time.deltaTime;

                if (myUIGroup.alpha == 0)
                {
                    fadeOut = true;
                    
                    fadeIn = false;
                }
            }
        }
    }
}
