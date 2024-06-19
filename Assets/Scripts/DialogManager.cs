using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    [SerializeField] private GameObject closeButton;
    [SerializeField] private Button cButton;
    [SerializeField] private TMP_Text dialogTxt;
    [SerializeField] private Button nextButton;
    [SerializeField] private GameObject button;
    [SerializeField] private CameraController cameraController;
    [SerializeField] private PlayerController playerController;

    [SerializeField] private string[] RabbitDialog;

    [SerializeField] private string[] OwlDialog;

    [SerializeField] private string[] SquirrelDialog1;
    [SerializeField] private string[] SquirrelDailog2;

    [SerializeField] private string[] BadgerDialog;

    [SerializeField] private string[] PoliceDialog1;
    [SerializeField] private string[] PoliceDialog2;

    private string[] dialogList;
    private int count = 0;
    private bool isTyping = false;
    private bool dialogueFinished = false;

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
        }
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
        button.SetActive(false);
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
        if (count<dialogLength-1)
        {
            button.SetActive(true);
        }
        else 
        {
            closeButton.SetActive(true);
            count = 0;
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
}
