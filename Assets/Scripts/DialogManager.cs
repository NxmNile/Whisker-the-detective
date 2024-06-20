using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    [SerializeField] private GameObject closeButton;
    
    [SerializeField] private TMP_Text dialogTxt;
   
    [SerializeField] private GameObject NextButton;
    [SerializeField] private CameraController cameraController;
    [SerializeField] private PlayerController playerController;

    [SerializeField] private string[] RabbitDialog;

    [SerializeField] private string[] OwlDialog;

    [SerializeField] private string[] SquirrelDialog1;
    [SerializeField] private string[] SquirrelDailog2;

    [SerializeField] private string[] BadgerDialog;

    [SerializeField] private string[] PoliceDialog1;
    [SerializeField] private string[] PoliceDialog2;
    [SerializeField] private string[] PoliceDialog3;
    [SerializeField] private string[] PoliceDialog4;
    [SerializeField] private string[] PoliceDialog5;
    [SerializeField] private string[] DetectiveDialog;
    
    [SerializeField] private GameObject YesButton;
    [SerializeField] private GameObject NoButton;

    [SerializeField] private GameObject Suspects;
    [SerializeField] private Button RabbitButton;
    [SerializeField] private Button OwlButton;
    [SerializeField] private Button SquirrelButton;
    [SerializeField] private Button BadgerButton;

    [SerializeField] private GameObject FailedScreen;
    [SerializeField] private GameObject CongratsScreen;

    [SerializeField] private RotateToTarget _toTarget;

    [SerializeField] private GameObject Image;
    //[SerializeField] private CameraController _cameraController;
    private string[] dialogList;
    private int count = 0;
    private bool isTyping = false;
    private bool dialogueFinished = false;
    private string dialogName;
    private int dialogLength = 0;
    private KeepData _keepData;
    private void Start()
    {
        _keepData = KeepData.Instance;
        RabbitButton.onClick.AddListener(()=>CheckMurderer(false));
        OwlButton.onClick.AddListener(()=>CheckMurderer(false));
        SquirrelButton.onClick.AddListener(()=>CheckMurderer(true));
        BadgerButton.onClick.AddListener(()=>CheckMurderer(false));
    }

    public void chooseDialog(string dialog)
    {
        switch (dialog)
        {
            case "RabbitDialog" :
                dialogList = RabbitDialog;
                break;
            case "OwlDialog":
                dialogList = OwlDialog;
                break;
            case "SquirrelDialog1":
                dialogList = SquirrelDialog1;
                break;
            case "SquirrelDialog2":
                dialogList = SquirrelDailog2;
                break;
            case "BadgerDialog":
                dialogList = BadgerDialog;
                break;
            case "PoliceDialog1":
                dialogList = PoliceDialog1;
                break;
            case "PoliceDialog2":
                dialogList = PoliceDialog2;
                break;
            case "PoliceDialog3":
                dialogList = PoliceDialog3;
                break;
            case "PoliceDialog4":
                dialogList = PoliceDialog4;
                break;
            case "PoliceDialog5":
                dialogList = PoliceDialog5;
                break;
            case "DetectiveDialog":
                dialogList = DetectiveDialog;
                break;
        }
        dialogName = dialog;
        dialogLength = dialogList.Length;
        DisplayNextSentence();
    }
    public void DisplayNextSentence()
    {
        ClearDialogue();
        StartCoroutine(typeSentence(dialogList[count]));
    }
    IEnumerator typeSentence(string sentence)
    {
        if (dialogName=="SquirrelDialog2")
        {
            Suspects.SetActive(false);
        }
        NextButton.SetActive(false);
        closeButton.SetActive(false);
        foreach (char letter in dialogList[count].ToCharArray())
        {
            isTyping = true;
            dialogTxt.text += letter;
            yield return new WaitForSeconds(0.02f); // Adjust speed of typing here
        }
        ++count;
        isTyping = false;
        dialogueFinished = true;
        if (count<dialogLength)
        {
            NextButton.SetActive(true);
        }
        else 
        {
            closeButton.SetActive(true);
            count = 0;
        }

        if (dialogName == "PoliceDialog2")
        {   
            NextButton.SetActive(false);
            YesButton.SetActive(true);
            NoButton.SetActive(true);
        }
        else if (dialogName == "PoliceDialog3")
        {
           Suspects.SetActive(true);
        }
        else if (dialogName == "PoliceDialog4")// incorrect answer
        {   
            closeButton.SetActive(false);
            Invoke("Failed",2f);
        }
        else if (dialogName == "PoliceDialog5")//correct answer
        {
            NextButton.SetActive(false);
            closeButton.SetActive(false);
            Invoke("Winning",3f);
        }
        else if(dialogName=="SquirrelDialog2") //confess
        {   
            NextButton.SetActive(false);
            closeButton.SetActive(false);
         
        }
    }

    public void CloseButton()
    {   
        NoButton.SetActive(false);
        YesButton.SetActive(false);
        Suspects.SetActive(false);
        this.gameObject.SetActive(false);
        playerController.moveSpeed = playerController.initialSpeed;
        playerController.IsTalking = false;
        cameraController.MoveCameraBack();
    }

    private void ClearDialogue()
    {
        dialogTxt.text = "";
    }

    public void CheckMurderer(bool check)
    {
        if (check)
        {   
            cameraController.MoveCamera(2);
            ClearDialogue();
            chooseDialog("SquirrelDialog2");
            Invoke("Complete",3f);
        }
        else
        {   
            Suspects.SetActive(false);
            chooseDialog("PoliceDialog4");
        }
    }

    public void ReadyButton()
    {   
        //Debug.Log("REady");
        count = 0;
        ClearDialogue();
        NextButton.SetActive(false);
        closeButton.SetActive(false);
        YesButton.SetActive(false);
        NoButton.SetActive(false);
        chooseDialog("PoliceDialog3");
    }

    private void Failed()
    {   
        FailedScreen.SetActive(true);
        this.gameObject.SetActive(false);
    }

    private void Complete()
    {
        cameraController.MoveCamera(4);
        chooseDialog("PoliceDialog5");
    }

    private void Winning()
    {
        Image.SetActive(true);
        ClearDialogue();
        chooseDialog("DetectiveDialog");
        Invoke("LastScreen",2f);
    }

    private void LastScreen()
    {   
        this.gameObject.SetActive(false);
        CongratsScreen.SetActive(true);
    }
    
    
}
