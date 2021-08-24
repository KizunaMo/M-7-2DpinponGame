using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    
    public Dialogue dialogue;

    public static DialogueTrigger dialogueTrigger;
    public bool triggered = false;
    public bool ballActive = false;

    private void Awake()
    {
        MakeSingleton();   
    }

    public void TriggerDialogue()
    {
        AudioManager.instance.Play("StartConversation");
        DialogueManager.instance.StartDialogue(dialogue);
        triggered = true;
    }

    void MakeSingleton()
    {
        if(dialogueTrigger == null)
        {
            dialogueTrigger = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }


}
