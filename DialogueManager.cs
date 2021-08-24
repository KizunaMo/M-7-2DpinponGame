using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    [Header("Setting")]
    [SerializeField] private Text nameText;//���ܪ�
    [SerializeField] private Text dialogueText;//���ܤ��e

    private Queue<string> queueSentences;//�s�W�@�ӹ�CQueue�s��string�W��sentences

    public static DialogueManager instance;

    private void Awake()
    {
        MakeSingleton();
    }

    // Start is called before the first frame update
    void Start()
    {
        queueSentences = new Queue<string>();//��sentences�����
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
        nameText.text = dialogue.name;//ClassDialogue��name�ǵ�nameText.text
        queueSentences.Clear();//�}�l��ܫe���M�żƾ�
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
