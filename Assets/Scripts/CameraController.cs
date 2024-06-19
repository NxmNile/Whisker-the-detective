using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform[] cameraPosition;
    private Transform targetPosition;  // The target position for the camera to move to
    private Vector3 originalPosition; // The original position of the camera
    private Quaternion originalRotation; // The original rotation of the camera

    private void Start()
    {
        // Store the original position and rotation of the camera
        originalPosition = transform.position;
        originalRotation = transform.rotation;
    }
    
    public void MoveCamera(int i)
    {
        targetPosition = cameraPosition[i];
        transform.position = targetPosition.position;
        transform.rotation = targetPosition.rotation;
    }

    public void MoveCameraBack()
    {
        transform.position = originalPosition;
        transform.rotation = originalRotation;
    }
}
