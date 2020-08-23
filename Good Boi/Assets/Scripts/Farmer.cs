using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Farmer : MonoBehaviour
{
    [SerializeField]
    private Dialogue[] dialoguesArray;
    private Queue<Dialogue> dialogues = new Queue<Dialogue>();

    private void Start()
    {
        foreach (Dialogue dialogue in dialoguesArray)
        {
            dialogues.Enqueue(dialogue);
        }
    }

    public void Interact(Dog player)
    {
        Dialogue nextDialogue = dialogues.Dequeue();
        DialogueManager.GetInstance().PlayDialogue(nextDialogue);
    }
}
