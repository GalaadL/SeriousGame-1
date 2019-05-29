using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickDialogueTrigger : DialogueTrigger
{
    public OnClickDialogueTrigger() { }

    public void TriggerDialogue()
    {
        dialogue = load_dialogue(dialoguePath);
        FindObjectOfType<OnClickDialogueManager>().StartDialogue(dialogue);
    }

}
