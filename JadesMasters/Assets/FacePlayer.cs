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
            // Get only the Y-axis rotation of the player
            Vector3 targetRotation = new Vector3(0, playerTransform.eulerAngles.y, 0);

            // Apply it to this object
            transform.rotation = Quaternion.Euler(targetRotation);
        }
    }

}
