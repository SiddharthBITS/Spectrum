using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorWheelRotator : MonoBehaviour
{
    public float rotationSpeed = 100f;
    public GameObject center;

    void Update()
    {
        transform.RotateAround(center.transform.position, new Vector3(0, 0, -1), rotationSpeed * Time.deltaTime);
    }
}
