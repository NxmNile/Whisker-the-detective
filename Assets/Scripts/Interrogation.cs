using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interrogation : MonoBehaviour
{
    [SerializeField] private GameObject[] interrogationUI;
    [SerializeField] private CameraController cameraController;
    [SerializeField] private PlayerController playerController;
    public int index;
    private bool IsInCollider = false;
    public string objectName;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)&&IsInCollider)
        {
            cameraController.ChangeCamera(index+1);
            playerController.moveSpeed = 0;
            playerController.IsTalking = true;

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        IsInCollider = true;
        
        objectName = other.gameObject.name;
        if (objectName == "RabbitDesk")
        {
            index = 0;
        }
        else if(objectName=="OwlDesk")
        {
            index = 1;
        }
        else if (objectName == "SquirrelDesk")
        {
            index = 2;
        }
        else if (objectName == "BadgerDesk")
        {
            index = 3;
        }
        else if(objectName=="Police")
        {
            index = 4;
        }
        else if (objectName == "StationDoor")
        {
            index = 5;
        }
        interrogationUI[index].SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        IsInCollider = false;
        interrogationUI[index].SetActive(false);
    }

    private void CloseDialog()
    {
        playerController.moveSpeed = playerController.initialSpeed;
        playerController.IsTalking = false;
        cameraController.ChangeCamera(0);
    }
}
