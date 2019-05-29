﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Xml.Serialization;
using System.Xml;
using System.IO;

public class DialogueManager : MonoBehaviour
{

    public Text nameText;
    public Text dialogueText;

    public Animator animator;

    protected Queue<string> sentences;
    protected Queue<Speech> speeches;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        speeches = new Queue<Speech>();
    }

    public void StartDialogue (Dialogue dialogue)
    {
        animator.SetBool("IsOpen", true);

        speeches.Clear();
        sentences.Clear();

        foreach (Speech speech in dialogue.discution)
        {
            speeches.Enqueue(speech);
        }

        DisplayNextSpeech();

    }

    public void DisplayNextSpeech()
    {
        Speech speech = speeches.Dequeue();
        nameText.text = speech.name;

        foreach (string sentence in speech.sentences)
        {
            sentences.Enqueue(sentence);
        }
       
            DisplayNextSentence();


    }

    public void DisplayNextSentence ()
    {
        if (sentences.Count == 0)
        {
            if (speeches.Count == 0)
            {
                EndDialogue();
                return;
            }
            else
            {
                DisplayNextSpeech();
                return;
            }
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
        WaitNextSentence();
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    // For the Automatic Dialogue, on the top of the screen, which go on alone

  
    void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
    }

    void WaitNextSentence()
    {
        return;
    }

 
}