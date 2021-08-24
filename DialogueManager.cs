using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    [Header("Setting")]
    [SerializeField] private Text nameText;//說話者
    [SerializeField] private Text dialogueText;//說話內容

    private Queue<string> queueSentences;//新增一個對列Queue存放string名為sentences

    public static DialogueManager instance;

    private void Awake()
    {
        MakeSingleton();
    }

    // Start is called before the first frame update
    void Start()
    {
        queueSentences = new Queue<string>();//讓sentences實體化
    }

    void MakeSingleton()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }
    
    public void StartDialogue(Dialogue dialogue)
    {
        nameText.text = dialogue.name;//ClassDialogue的name傳給nameText.text
        queueSentences.Clear();//開始對話前先清空數據
        foreach (string sentence in dialogue.sentences)
        {
            queueSentences.Enqueue(sentence);
        }
        DisPlayNextSentence();
    }

    public void DisPlayNextSentence()
    {
        AudioManager.instance.Play("Continue");
        if(queueSentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        string sentence = queueSentences.Dequeue();
        dialogueText.text = sentence;
    }

    public void EndDialogue()
    {
        Debug.Log("End");
        DialogueTrigger.dialogueTrigger.triggered = false;
        DialogueTrigger.dialogueTrigger.ballActive = true;
    }


}
