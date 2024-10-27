using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spinObject : MonoBehaviour
{
    // Speed of rotation in degrees per second
    [SerializeField] private float rotationSpeed = 100f;

    void Update()
    {
        // Rotate the object around the Z axis
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }
}
