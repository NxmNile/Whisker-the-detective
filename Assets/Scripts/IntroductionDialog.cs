using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class IntroductionDialog : MonoBehaviour
{
    [SerializeField] private TMP_Text dialogTxt;
    [SerializeField] private Button playButton;
    [SerializeField] private GameObject GoButton;
    [SerializeField] private string[] DialogList;
    private bool isTyping = false;
    private bool dialogueFinished = false;
    private int count = 0;
    private string sentences;
    private void Start()
    {   
        SoundManager.instance.Play(SoundManager.SoundName.PhoneRing);
        Invoke("PickUpPhone",2f);
    }

    IEnumerator typeSentence(string sentence)
    {
        foreach (char letter in DialogList[count].ToCharArray())
        {
            isTyping = true;
            dialogTxt.text += letter;
            
            yield return new WaitForSeconds(0.02f); // Adjust speed of typing here
        }
        ++count;
        isTyping = false;
        dialogueFinished = true;
        dialogTxt.text += "\n";
        if (count < DialogList.Length)
        {
            Invoke("DisPlayNext",1.5f);
        }
        else
        {
            GoButton.SetActive(true);
        }
        
        
        
    }

    private void DisPlayNext()
    {
        StartCoroutine(typeSentence(sentences));
    }
   
    private void ClearDialogue()
    {
        dialogTxt.text = "";
    }

    private void PickUpPhone()
    {   
        SoundManager.instance.Stop(SoundManager.SoundName.PhoneRing);
        SoundManager.instance.Play(SoundManager.SoundName.PickUpPhone);
        Invoke("StartDialog",2f);
    }

    private void StartDialog()
    {
        sentences = DialogList[count];
        StartCoroutine(typeSentence(sentences));
    }
}
