using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    [SerializeField]
    private DialogueUI dialogueUi;
    [SerializeField]
    private Animator uIAnimator;

    private bool isDialoguePlaying = false;
    public bool IsDialoguePlaying
    {
        get{ return isDialoguePlaying; }
    }
    private Queue<string> sentences = new Queue<string>();
    private static DialogueManager instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    private void Update()
    {
        if(!isDialoguePlaying)
        {
            return;
        }

        StartCoroutine(ListenForKeys());
    }

    private IEnumerator ListenForKeys()
    {
        yield return null;
        if(Input.GetKeyDown(KeyCode.Space)){
            DisplayNextSentence();
        }
    }

    public static DialogueManager GetInstance()
    {
        return instance;
    }

    public void PlayDialogue(Dialogue dialogue)
    {
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        dialogueUi.setNameText(dialogue.name);
        StartDialogue();
    }

    private void StartDialogue()
    {
        isDialoguePlaying = true;
        uIAnimator.SetBool("isVisible", true);
        DisplayNextSentence();
    }

    private void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
        }
        else
        {
            dialogueUi.setSentenceText(sentences.Dequeue());
        }
    }

    private void EndDialogue()
    {
        uIAnimator.SetBool("isVisible", false);
        sentences.Clear();
        StopCoroutine(ListenForKeys());
        StartCoroutine(setIsDialoguePlayingToFalse());
    }

    private IEnumerator setIsDialoguePlayingToFalse()
    {
        //wait 1 frame update before setting isDialoguePlaying to false,
        //otherwise other gameobjects would get the last space keydown in Update()
        yield return null;
        isDialoguePlaying = false;
    }
}
