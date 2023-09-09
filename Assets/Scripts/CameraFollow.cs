using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;        
    public Vector3 offsetPosition;  
    public Vector3 offsetRotation;
 

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            return;
        }

        transform.position = target.position + offsetPosition;
        transform.rotation = target.rotation * Quaternion.Euler(offsetRotation);
    }
}
