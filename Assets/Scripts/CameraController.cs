using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Camera MainCamera;
    [SerializeField] private Camera RabbitCamera;
    [SerializeField] private Camera OwlCamera;
    [SerializeField] private Camera SquirrelCamera;
    [SerializeField] private Camera BadgerCamera;
    [SerializeField] private Camera PoliceCamera;
    private Camera[] allcamera;
    private void Start()
    {
        
        allcamera = new[] { MainCamera, RabbitCamera, OwlCamera, SquirrelCamera, BadgerCamera, PoliceCamera };
       
        ChangeCamera(0);
    }

    public void ChangeCamera(int cameraNumber)
    {
        for (int j = 0; j < allcamera.Length; j++)
        {
            if(j==cameraNumber)
            {
                allcamera[j].enabled = true;
            }
            else
            {
                allcamera[j].enabled = false;
            }
        }
    }
    
}
