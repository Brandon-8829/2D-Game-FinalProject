/*
 * Script for the Camera. Holds all functions and variables realative to the Camera.
 * 
 * Author: Brandon Harris
 * 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CameraFollow : MonoBehaviour {

    public Transform target;
    public Vector3 offset;
    

    //the time it takes for the camera to lock onto the target.
    public float smoothspeed = 0.125f;

    void LateUpdate()
    {
        //add some vector math to speed up the smoothing process and fix camera bugs associated with it.
        Vector3 desirePosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desirePosition, smoothspeed*Time.deltaTime);
        transform.position = target.position + offset; // adding two vectors

        transform.LookAt(target);
    }
}
