using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Interrogation : MonoBehaviour
{
    [SerializeField] private GameObject[] interrogationUI;
    [SerializeField] private CameraController cameraController;
    [SerializeField] private PlayerController playerController;
    [SerializeField] private GameObject Dialog;
    [SerializeField] private DialogManager dialogManager;
    private KeepData _keepData;
    public int index;
    private bool IsInCollider = false;
    public string objectName;

    private void Start()
    {
        _keepData = KeepData.Instance;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)&&IsInCollider&&objectName!="StationDoor")
        {   
            interrogationUI[index].SetActive(false);
            Dialog.SetActive(true);
            cameraController.MoveCamera(index);
            playerController.moveSpeed = 0;
            playerController.IsTalking = true;
            if (objectName == "RabbitDesk")
            {
                dialogManager.chooseDialog("RabbitDialog");
                _keepData.dialogList[index] = true;
                Debug.Log(_keepData.dialogList[index] );
            }
            else if(objectName=="OwlDesk")
            {
                dialogManager.chooseDialog("OwlDialog");
                _keepData.dialogList[index] = true;
                Debug.Log(_keepData.dialogList[index] );
            }
            else if (objectName == "SquirrelDesk")
            {
                dialogManager.chooseDialog("SquirrelDialog1");
                _keepData.dialogList[index] = true;
                Debug.Log(_keepData.dialogList[index] );
            }
            else if (objectName == "BadgerDesk")
            {   
                _keepData.dialogList[index] = true;
                Debug.Log(_keepData.dialogList[index] );
                dialogManager.chooseDialog("BadgerDialog");
            }
            else if(objectName=="Police")
            {
                if (!_keepData.dialogCheck())
                {
                    dialogManager.chooseDialog("PoliceDialog1");
                }
                else
                {
                    dialogManager.chooseDialog("PoliceDialog2");
                }
                //dialogManager.chooseDialog("PoliceDialog2");
            }
            
        }
        else if (Input.GetKeyDown(KeyCode.F) && IsInCollider && objectName == "StationDoor")
        {
            _keepData.sceneName = "WorldMain";
            SoundManager.instance.Stop(SoundManager.SoundName.BGM);
            SoundManager.instance.Play(SoundManager.SoundName.BGM2);
            SceneManager.LoadScene("World 2");
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
        Debug.Log(objectName);
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
        cameraController.MoveCameraBack();
        
    }
}
