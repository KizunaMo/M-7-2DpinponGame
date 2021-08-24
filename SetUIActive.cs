using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetUIActive : MonoBehaviour
{
    [Header("Setting")]
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private GameObject startTeachButton;
    [SerializeField] private GameObject pressText;

    private void Update()
    {
        DialogueUIActive();
    }

    public void DialogueUIActive()
    {
        if (DialogueTrigger.dialogueTrigger.triggered)
        {
            dialoguePanel.SetActive(true);
            startTeachButton.SetActive(false);
            pressText.SetActive(false);
        }
        else
        {
            dialoguePanel.SetActive(false);
        }
    }


}
