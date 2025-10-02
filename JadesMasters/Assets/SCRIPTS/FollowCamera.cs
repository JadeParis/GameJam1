using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform player;
    public Vector3 offset; // Set this in the Inspector to control camera distance/angle

    void LateUpdate()
    {
        if (player != null)
        {
            transform.rotation = player.rotation;
        }
    }



}
