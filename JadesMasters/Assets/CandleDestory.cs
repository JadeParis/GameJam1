using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandleDestory : MonoBehaviour
{
    public Interact interact;


    private void Update()
    {
        if ( interact.CandleCollected)
        {
            Destroy(gameObject);
        }
    }
}
