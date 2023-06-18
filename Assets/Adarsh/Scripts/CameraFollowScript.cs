using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowScript : MonoBehaviour

{
    private Transform playerTransform;

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void LateUpdate()
    {
        Vector3 newCameraPos = transform.position;

        newCameraPos.x = playerTransform.position.x;
        newCameraPos.y = playerTransform.position.y;

        transform.position = newCameraPos;
    }
}
