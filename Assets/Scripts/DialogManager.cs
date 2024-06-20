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
    [SerializeField] private GameObject YesButton;
    [SerializeField] private GameObject NoButton;

    [SerializeField] private GameObject RabbitButton;
    [SerializeField] private GameObject OwlButton;
    [SerializeField] private GameObject SquirrelButton;
    [SerializeField] private GameObject BadgerButton;
    private string[] dialogList;
    private int count = 0;
    private bool isTyping = false;
    private bool dialogueFinished = false;
    private string dialogName;
    private int dialogLength = 0;
    // Start is called before the first frame update
    

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
                dialogList = PoliceDialog2;
                break;
            case "PoliceDialog4":
                dialogList = PoliceDialog2;
                break;
            case "PoliceDialog5":
                dialogList = PoliceDialog2;
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
            YesButton.SetActive(true);
            NoButton.SetActive(true);
        }
        
    }

    public void CloseButton()
    {
        this.gameObject.SetActive(false);
        playerController.moveSpeed = playerController.initialSpeed;
        playerController.IsTalking = false;
        cameraController.MoveCameraBack();
    }

    private void ClearDialogue()
    {
        dialogTxt.text = "";
    }

    public void ChooseMurderer()
    {
        if (this.gameObject.name == "SquirrelButton")
        {
            Debug.Log("Yes");
        }
        else
        {
            Debug.Log("NO");
        }
    }

    public void ReadyButton()
    {
        count = 0;
        NextButton.SetActive(false);
        closeButton.SetActive(false);
        ClearDialogue();
        RabbitButton.SetActive(true);
        OwlButton.SetActive(true);
        SquirrelButton.SetActive(true);
        BadgerButton.SetActive(true);
    }
    
}
