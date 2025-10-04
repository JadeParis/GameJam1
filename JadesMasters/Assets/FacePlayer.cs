using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacePlayer : MonoBehaviour
{
    public Transform playerTransform;

    public void Awake()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
            playerTransform = player.transform;
            Debug.Log("player not found");

    }
    private void Update()
    {
        FacePlayerDirection();
    }

    public void FacePlayerDirection()
    {
        if (playerTransform != null)
        {
            transform.rotation = playerTransform.rotation;
        }
    }

}
